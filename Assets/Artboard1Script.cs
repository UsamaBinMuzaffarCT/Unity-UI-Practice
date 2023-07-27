using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artboard1Script : MonoBehaviour
{
    #region variables

    [SerializeField] private Image photo;
    [SerializeField] private GameObject photoContainer;
    [SerializeField] private Button optionsButtonHeart;
    [SerializeField] private Button optionsButtonDress;
    [SerializeField] private Button optionsButtonPerson;
    [SerializeField] private Button optionsButtonSweater;
    [SerializeField] private Button optionsButtonShirt;
    [SerializeField] private Button optionsButtonBoots;
    private List<int> avatarIDs;

    #endregion

    #region functions

    #region private-functions

    //Unity Functions

    private void Awake()
    {
        optionsButtonPerson.onClick.AddListener(() => LoadArtBoard2Screen(CustomizationManager.PositionNames.face, CustomizationManager.Customizer.Hair));
        optionsButtonDress.onClick.AddListener(() => LoadArtBoard2Screen(CustomizationManager.PositionNames.torso, CustomizationManager.Customizer.Clothes));
        optionsButtonBoots.onClick.AddListener(() => LoadArtBoard2Screen(CustomizationManager.PositionNames.feet, CustomizationManager.Customizer.Shoes));
        optionsButtonSweater.onClick.AddListener(() => LoadArtBoard2Screen(CustomizationManager.PositionNames.torso, CustomizationManager.Customizer.Clothes));
        optionsButtonShirt.onClick.AddListener(() => LoadArtBoard2Screen(CustomizationManager.PositionNames.torso, CustomizationManager.Customizer.Clothes));
        optionsButtonHeart.onClick.AddListener(() => LoadArtBoardWishlist());
        CustomizationManager.instance.prevPosition = CustomizationManager.PositionNames.front;
        avatarIDs = UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].avatarIDs;
    }

    private void Start()
    {
        PopulateScrollView();
    }

    //Non-Unity Functions

    private void ClearScrollView()
    {
        foreach (Transform child in photoContainer.transform)
        {
            Destroy(child);
        }
    }

    private void PopulateScrollView()
    {
        ClearScrollView();
        foreach (int id in avatarIDs)
        {
            Image loadedPhoto = Instantiate(photo);
            loadedPhoto.transform.SetParent(photoContainer.transform);
            if (UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarGender == CustomizationManager.Gender.Male)
            {
                loadedPhoto.sprite = CustomizationManager.instance.avatars.avatars.Find(x => x.id == id).maleImage;
            }
            else
            {
                loadedPhoto.sprite = CustomizationManager.instance.avatars.avatars.Find(x => x.id == id).femaleImage;
            }
            loadedPhoto.GetComponent<AvatarInfo>().id = id;
            loadedPhoto.gameObject.transform.GetComponent<Button>().onClick.AddListener(() => UpdateCurrentAssetPath(id));
        }
    }

    private void UpdateCurrentAssetPath(int id)
    {
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID = id;
        UI_Manager.TriggerAvatarButtonEvent();
        CustomizationManager.instance.UpdateAvatar(id, UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarGender);
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArtBoard2Screen(CustomizationManager.PositionNames positionName, CustomizationManager.Customizer customizer)
    {
        CustomizationManager.instance.SetCustomizer(customizer);
        CustomizationManager.instance.MoveCameraTo(positionName);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }

    public void LoadArtBoardWishlist()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardWishlist);
    }

    public void LoadArtBoardSave()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave);
    }

    #endregion

    #endregion
}
