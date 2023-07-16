using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class UI_Manager : MonoBehaviour
{
    #region enumerators

    [Serializable]
    public class PlayerInfo
    {
        public string email;
        public string phoneNumber;
        public string password;
        public List<string> imagesList;
    }

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

    #region variables

    #region public-variables

    public static UI_Manager instance { get; private set; }
    //public GameObject[] screensArray;

    #endregion

    #region private-variables

    [SerializeField] private ScreenScriptableObject screens;
    [SerializeField] private Canvas canvas;
    private GameObject currentScreen;

    #endregion
    
    #endregion

    #region datastructures

    private Stack<GameObject> backStack = new Stack<GameObject>();

    #endregion

    #region events

    #endregion

    #region delegates

    #endregion

    #region functions

    #region private-functions

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
        else { 
            return ""; 
        }
    }

    private void TestFunction()
    {
        List<string> images = new List<string> {
            "Assets/Test/image1.jpg", 
            "Assets/Test/image2.jpg", 
            "Assets/Test/image3.jpg" 
        };
        PlayerInfo playerInfo = new PlayerInfo
        {
            imagesList = images,
            email = "abc@gmail.com",
            phoneNumber = "1234567890",
            password = "password",
        };

        List<PlayerInfo> playerInfos = new List<PlayerInfo>();
        playerInfos.Add(playerInfo);
        playerInfos.Add(playerInfo);


        //string json = JsonUtility.ToJson(playerInfos);
        string json = JsonConvert.SerializeObject(playerInfos);
        FileStream fileStream = new FileStream("Assets/save.json", FileMode.Create);
        using(StreamWriter writer = new StreamWriter(fileStream)) 
        { 
            writer.Write(json);
        }
        string readJSON = ReadJSON("Assets/save.json");
        List<PlayerInfo> playerInfos1 = JsonConvert.DeserializeObject<List<PlayerInfo>>(readJSON);
        Debug.Log(playerInfos1[0].email);
    }

    private void Awake()
    {
        TestFunction();
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
       GameObject loadedScreen = Instantiate(screens.Screens.Find(x=>x.screen==Screen.I_LogoScreen).prefab);
       loadedScreen.transform.SetParent(canvas.transform, false);
       currentScreen = loadedScreen;
       Invoke("GoToLogin", 3f);
    }
    private void GoToLogin()
    {
        GameObject loadedScreen = Instantiate(screens.Screens.Find(x => x.screen == Screen.B_WannaLoginScreen).prefab);
        loadedScreen.transform.SetParent(canvas.transform, false);
        currentScreen.SetActive(false);
        currentScreen = loadedScreen;
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
        }
        return;
    }

    private void ClearStack()
    {
        backStack.Clear();
    }

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

    #endregion

    #region public-functions

    public void MakeLoader()
    {
        GameObject loadingScreen = Instantiate(screens.Screens.Find(x => x.screen == Screen.A_LoadingPanel).prefab);
        loadingScreen.transform.SetParent(canvas.transform, false);
    }

    public void Back()
    {
        currentScreen.SetActive(false);
        currentScreen = PopFromStack();
        currentScreen.SetActive(true);
        Debug.Log("Stack Size : " + backStack.Count.ToString());

    }

    public void NextScreen(Screen screen, bool clear=false, bool logout=false)
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
                    PushToStack(currentScreen);
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
                PushToStack(currentScreen);
            }
            currentScreen = loadedScreen;
            if (backStack.Count > 2)
            {
                CheckPrevious();
            }
        }
        Debug.Log("Stack Size : " + backStack.Count.ToString());
    }
    
    #endregion
    
    #endregion

}
