using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class UI_Manager : MonoBehaviour
{
    #region classes

    [Serializable]
    public class PlayerInfo
    {
        public string name;
        public string email;
        public string phoneNumber;
        public string password;
        public string imageFolder;
        public string itemsFolder;
        public string avatarFolder;
        public string currentAvatar;

        public PlayerInfo() 
        {
            avatarFolder = "";
            itemsFolder = "";
            imageFolder = "";
            email = "";
            phoneNumber = "";
            password = "";
            name = "";
            currentAvatar = "";
        }
    }

    #endregion

    #region enumerators

    public enum Screen
    {
        A_LoadingPanel,
        B_WannaLoginScreen,
        C_LoginScreen,
        D_SignUpScreen,
        E_EnterNumberScreen,
        F_EnterEmailScreen,
        G_OTPScreen,
        H_SetPasswordScreen,
        I_LogoScreen,
        J_EnterNameScreen,
        K_ForgoPassScreen,
        L_ConfirmPassScreen,
        M_OldNewPassScreen,
        N_SelectCountryScreen,
        O_ViewProfileScreen,
        P_SettingsScreen,
        Q_AccountSettingsScreen,
        R_EditProfileScreen,
        S_ArtBoard1,
        T_ArtBoard2,
        U_ArtBoard3,
        V_ArtBoard4,
        W_ArtBoard5,
        X_ArtBoardColorPanel,
        Y_ArtBoardColors,
        Z_ArtBoardFace,
        ZA_ArtBoardWishlist,
        ZB_ArtBoardSave
    }

    #endregion

    #region delegates

    public delegate void ButtonClickEvent();

    #endregion

    #region events

    public static event ButtonClickEvent OnAvatarButtonClick;

    #endregion


    #region variables

    #region public-variables

    public static UI_Manager instance { get; private set; }
    public List<PlayerInfo> playerInfos;
    public SignupScript signupScript;
    public Image currentAvatar;
    public int currentUser;

    #endregion

    #region private-variables

    [SerializeField] private GameObject popup;
    [SerializeField] private ScreenScriptableObject screens;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas popupCanvas;
    private GameObject currentScreen;

    #endregion
    
    #endregion

    #region datastructures

    private Stack<GameObject> backStack = new Stack<GameObject>();

    #endregion

    #region functions

    #region private-functions

    private bool CheckExtention(String input)
    {
        String result = input.Substring(input.Length - 4);
        if (result == "meta")
        {
            return false;
        }
        return true;
    }

    private void CreateAvatarPNGs(RenderTexture renderTexture, string path)
    {
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        var bytes = texture.EncodeToPNG();
        File.WriteAllBytes(path + "/" + renderTexture.name + ".png", bytes);
    }

    private void CreateAllAvatarViews()
    {
        List<string> avatarPaths = new List<string>();
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/RenderTextures");
        FileInfo[] info = dir.GetFiles("*.*");

        foreach (FileInfo f in info)
        {
            if (CheckExtention(f.FullName))
            {
                avatarPaths.Add("RenderTextures/" + f.Name.ToString().Substring(0, f.Name.ToString().Length - 14));
            }
        }

        foreach(string path in avatarPaths)
        {
            RenderTexture renderTexture = Resources.Load<RenderTexture>(path);
            if (renderTexture != null)
            {
                if (!File.Exists("Assets/Resources/Test/" + renderTexture.name + ".png"))
                {
                    CreateAvatarPNGs(renderTexture, "Assets/Resources/Test");
                }
            }
            //DestroyImmediate(renderTexture);
        }
        AssetDatabase.Refresh();
    }

    private void WriteJSON(string path, List<PlayerInfo>playerInfos)
    {
        string json = JsonConvert.SerializeObject(playerInfos);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadJSON(string path)
    {
        if(File.Exists(path))
        {
            using(StreamReader reader =  new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else 
        { 
            return ""; 
        }
    }

    // make init function
    private void Awake()
    {

        currentUser = -1;
        string readJSON = ReadJSON("Assets/JSON/save.json");
        playerInfos = JsonConvert.DeserializeObject<List<PlayerInfo>>(readJSON);
        Debug.Log(playerInfos.Count);
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // make starting UI function
    void Start()
    {
       GameObject loadedScreen = Instantiate(screens.Screens.Find(x=>x.screen==Screen.I_LogoScreen).prefab);
       loadedScreen.transform.SetParent(canvas.transform, false);
       currentScreen = loadedScreen;
       Invoke("GoToLogin", 3f);
    }

    // Naming convention for loading
    private void GoToLogin()
    {
        GameObject loadedScreen = Instantiate(screens.Screens.Find(x => x.screen == Screen.B_WannaLoginScreen).prefab);
        loadedScreen.transform.SetParent(canvas.transform, false);
        currentScreen.SetActive(false);
        currentScreen = loadedScreen;
        CreateAllAvatarViews();
    }

    private void PushToStack(GameObject stackScreen)
    {
        backStack.Push(stackScreen);
    }

    private GameObject PopFromStack()
    {
        GameObject screen = backStack.Pop();
        return screen;
    }

    private void ClearTill(GameObject screen)
    {
        while(backStack.Count > 0)
        {
            GameObject top = PopFromStack();
            if (screen.transform.name == CloneName(top))
            {
                return;
            }
            Destroy(top);
        }
        return;
    }

    private void ClearStack()
    {
        backStack.Clear();
    }

    // Rename to RemoveCloneFromName
    private string CloneName(GameObject obj)
    {
        string name = obj.transform.name;
        string obj_name = "";
        for(int i = 0;i < name.Length-7;i++)
        {
            obj_name += name[i];
        }
        return obj_name;
    }

    private void CheckPrevious()
    {
        GameObject prevScreen = backStack.Pop();
        GameObject prevprevScreen = backStack.Pop();
        if( CloneName(prevScreen) == CloneName(backStack.Peek())) 
        {
            return;
        }
        else
        {
            PushToStack(prevprevScreen);
            PushToStack(prevScreen);
        }
    }

    private void HidePopup()
    {
        foreach(Transform child in canvas.transform)
        {
            if(child.tag == "popup")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    #endregion

    #region public-functions

    public static void RaiseButtonClickEvent()
    {
        if (OnAvatarButtonClick != null)
        {
            OnAvatarButtonClick.Invoke();
        }
    }

    public void UpdateJson()
    {
        WriteJSON("Assets/JSON/save.json", playerInfos);
    }

    public GameObject PeekTop()
    {
        return backStack.Peek();
    }

    public void MakePopup(string text)
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.tag == "popup")
            {
                child.transform.SetAsLastSibling();
                child.GetComponent<TMP_Text>().text = text;
                child.gameObject.SetActive(true);
                Invoke(nameof(HidePopup), 2);
            }
        }
    }

    public void MakeLoader()
    {
        GameObject loadingScreen = Instantiate(screens.Screens.Find(x => x.screen == Screen.A_LoadingPanel).prefab);
        loadingScreen.transform.SetParent(canvas.transform, false);
    }

    public void Back(bool add = true)
    {
        currentScreen.SetActive(false);
        currentScreen = PopFromStack();
        currentScreen.SetActive(true);
        Debug.Log("Stack Size : " + backStack.Count.ToString());

    }

    public void NextScreen(Screen screen, bool clear=false, bool add=true)
    {
        GameObject nextScreen = screens.Screens.Find(x => x.screen == screen).prefab;
        bool isPresent = false;
        if (clear)
        {
            ClearTill(nextScreen);
        }
        foreach (Transform child in canvas.transform)
        {
            if(child.transform.tag == "loading")
            {
                Destroy(child.gameObject);
            }
            if(CloneName(child.gameObject) == nextScreen.transform.name)
            {
                isPresent = true;
                currentScreen.SetActive(false);
                if (!clear)
                {
                    if (add)
                    {
                        PushToStack(currentScreen);
                    }
                }
                child.gameObject.SetActive(true);
                currentScreen = child.gameObject;
                if(backStack.Count > 2)
                {
                    CheckPrevious();
                }
            }
        }
        if (!isPresent)
        {
            GameObject loadedScreen = Instantiate(nextScreen);
            loadedScreen.transform.SetParent(canvas.transform, false);
            currentScreen.SetActive(false);
            if (!clear)
            {
                if (add)
                {
                    PushToStack(currentScreen);
                }
            }
            currentScreen = loadedScreen;
            if (backStack.Count > 2)
            {
                CheckPrevious();
            }
            if(CloneName(loadedScreen) == "D-SignUpScreen")
            {
                signupScript = loadedScreen.GetComponent<SignupScript>();
            }
        }
        Debug.Log("Stack Size : " + backStack.Count.ToString());
    }
    
    #endregion
    
    #endregion

}
