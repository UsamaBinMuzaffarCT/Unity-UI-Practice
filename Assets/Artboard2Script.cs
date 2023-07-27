using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Artboard2Script : MonoBehaviour
{
    #region variables

    [SerializeField] private Image photo;
    [SerializeField] private GameObject photoContainer;
    [SerializeField] private Button maleButton;
    [SerializeField] private Button femaleButton;
    [SerializeField] private Button optionsButtonMy;
    [SerializeField] private Button optionsButtonHeart;
    [SerializeField] private Button optionsButtonDress;
    [SerializeField] private Button optionsButtonPerson;
    [SerializeField] private Button optionsButtonSweater;
    [SerializeField] private Button optionsButtonShirt;
    [SerializeField] private Button optionsButtonBoots;
    private string itemsFolderPath;

    #endregion

    #region functions
 
    #region private-functions

    //Unity Functions

    private void Awake()
    {
        optionsButtonMy.onClick.AddListener(() => Back());
        optionsButtonPerson.onClick.AddListener(() => MoveCameraTo(CustomizationManager.PositionNames.face, CustomizationManager.Customizer.Hair));
        optionsButtonDress.onClick.AddListener(() => MoveCameraTo(CustomizationManager.PositionNames.torso, CustomizationManager.Customizer.Clothes));
        optionsButtonBoots.onClick.AddListener(() => MoveCameraTo(CustomizationManager.PositionNames.feet, CustomizationManager.Customizer.Shoes));
        optionsButtonSweater.onClick.AddListener(() => MoveCameraTo(CustomizationManager.PositionNames.torso, CustomizationManager.Customizer.Clothes));
        optionsButtonShirt.onClick.AddListener(() => MoveCameraTo(CustomizationManager.PositionNames.torso, CustomizationManager.Customizer.Clothes));
        optionsButtonHeart.onClick.AddListener(() => LoadArtBoardWishlist());
        if (UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarGender == CustomizationManager.Gender.Male)
        {
            femaleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Normal;
            maleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Bold;
        }
        else
        {
            femaleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Bold;
            maleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Normal;
        }
        itemsFolderPath = UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].itemsFolder;
        PopulateScrollView();
    }

    // Non-Unity Functions

    private bool CheckExtention(String input)
    {
        String result = input.Substring(input.Length - 4);
        if (result == "meta")
        {
            return false;
        }
        return true;
    }

    private void ClearScrollView()
    {
        foreach (Transform child in photoContainer.transform)
        {
            Destroy(child);
        }
    }

    private List<string> GetItemsPaths()
    {
        List<string> itemPaths = new List<string>();
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/" + itemsFolderPath);
        FileInfo[] info = dir.GetFiles("*.*");

        foreach (FileInfo f in info)
        {
            if (CheckExtention(f.FullName))
            {
                itemPaths.Add(itemsFolderPath + "/" + f.Name.ToString().Substring(0, f.Name.ToString().Length - 4));
            }
        }
        return itemPaths;
    }

    private void PopulateScrollView()
    {
        ClearScrollView();
        List<string> itemPaths = GetItemsPaths();

        foreach (string avatarPath in itemPaths)
        {
            Image loadedPhoto = Instantiate(photo);
            loadedPhoto.transform.SetParent(photoContainer.transform);
            loadedPhoto.sprite = Resources.Load<Sprite>(avatarPath);
        }
    }

    #endregion

    #region public-functions

    public void Back()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.instance.prevPosition);
        UI_Manager.instance.Back();
        Destroy(gameObject);
    }

    public void LoadArtBoardColorsScreen()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardColors,add:false);
    }
    public void LoadArtBoardColorPanelScreen()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardColorPanel, add: false);
    }

    public void LoadArtBoard4()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard4);
    }

    public void LoadArtBoardFace()
    {
        CustomizationManager.instance.SetCustomizer(CustomizationManager.Customizer.Face);
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace,add:false);
    }

    public void MoveCameraTo(CustomizationManager.PositionNames positionName, CustomizationManager.Customizer customizer)
    {
        CustomizationManager.instance.SetCustomizer(customizer);
        CustomizationManager.instance.MoveCameraTo(positionName);
    }

    public void LoadArtBoardSave()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave, add: false);
    }

    public void LoadArtBoardWishlist()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardWishlist, add: false);
    }


    public void ToggleMale()
    {
        if (maleButton.GetComponentInChildren<TMP_Text>().fontStyle == TMPro.FontStyles.Normal)
        {
            femaleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Normal;
            maleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Bold;
            CustomizationManager.instance.UpdateAvatar(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID, CustomizationManager.Gender.Male, positionName: CustomizationManager.instance.currentPosition);
            UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarGender = CustomizationManager.Gender.Male;
        }
    }

    public void ToggelFemale()
    {
        if(femaleButton.GetComponentInChildren<TMP_Text>().fontStyle == TMPro.FontStyles.Normal)
        {
            femaleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Bold;
            maleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Normal;
            CustomizationManager.instance.UpdateAvatar(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID, CustomizationManager.Gender.Female, positionName: CustomizationManager.instance.currentPosition);
            UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarGender = CustomizationManager.Gender.Female;
        }
    }

    #endregion

    #endregion
}
