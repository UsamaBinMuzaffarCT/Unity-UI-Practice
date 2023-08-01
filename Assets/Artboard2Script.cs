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
            Destroy(child.gameObject);
        }
    }

    private void CreateButton(CustomizationManager.SpriteWithID spriteWithID)
    {
        Image loadedPhoto = Instantiate(photo);
        loadedPhoto.transform.SetParent(photoContainer.transform);
        loadedPhoto.sprite = spriteWithID.sprite;
        loadedPhoto.gameObject.GetComponent<AvatarInfo>().id = spriteWithID.id;
        loadedPhoto.gameObject.GetComponent<Button>().onClick.AddListener(() => CustomizationManager.instance.UpdateItem(spriteWithID.id));
    }

    private void PopulateScrollView()
    {
        ClearScrollView();
        if(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarGender == CustomizationManager.Gender.Male)
        {
            if (CustomizationManager.instance.customizer == CustomizationManager.Customizer.Face || CustomizationManager.instance.customizer == CustomizationManager.Customizer.Hair)
            {
                foreach(CustomizationManager.SpriteWithID spriteWithID in CustomizationManager.instance.avatars.avatars.Find(x=>x.id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID).maleSkin)
                {
                    CreateButton(spriteWithID);
                }
            }
            else
            {
                foreach (CustomizationManager.SpriteWithID spriteWithID in CustomizationManager.instance.avatars.avatars.Find(x => x.id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID).maleOutfits)
                {
                    CreateButton(spriteWithID);
                }
            }
        }
        else
        {
            if (CustomizationManager.instance.customizer == CustomizationManager.Customizer.Face || CustomizationManager.instance.customizer == CustomizationManager.Customizer.Hair)
            {
                foreach (CustomizationManager.SpriteWithID spriteWithID in CustomizationManager.instance.avatars.avatars.Find(x => x.id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID).femaleSkin)
                {
                    CreateButton(spriteWithID);
                }
            }
            else
            {
                foreach (CustomizationManager.SpriteWithID spriteWithID in CustomizationManager.instance.avatars.avatars.Find(x => x.id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID).femaleOutfits)
                {
                    CreateButton(spriteWithID);
                }
            }
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
        PopulateScrollView();
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
        PopulateScrollView();
    }

    public void ToggelFemale()
    {
        if (femaleButton.GetComponentInChildren<TMP_Text>().fontStyle == TMPro.FontStyles.Normal)
        {
            femaleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Bold;
            maleButton.GetComponentInChildren<TMP_Text>().fontStyle = TMPro.FontStyles.Normal;
            CustomizationManager.instance.UpdateAvatar(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID, CustomizationManager.Gender.Female, positionName: CustomizationManager.instance.currentPosition);
            UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarGender = CustomizationManager.Gender.Female;
        }
        PopulateScrollView();
    }

    #endregion

    #endregion
}
