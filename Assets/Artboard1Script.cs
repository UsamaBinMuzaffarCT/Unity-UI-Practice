using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Artboard1Script : MonoBehaviour
{
    #region variables

    [SerializeField] private Image photo;
    [SerializeField] private GameObject photoContainer;
    private List<int> avatarIDs;

    #endregion

    #region functions

    #region private-functions

    //Unity Functions

    private void Awake()
    {
        CustomizationManager.instance.prevPosition = CustomizationManager.PostionNames.front;
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
            loadedPhoto.sprite = CustomizationManager.instance.avatars.avatars.Find(x=>x.id == id).image;
            loadedPhoto.GetComponent<AvatarInfo>().id = id;
            loadedPhoto.gameObject.transform.GetComponent<Button>().onClick.AddListener(() => UpdateCurrentAssetPath(id));
        }
    }

    private void UpdateCurrentAssetPath(int id)
    {
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID = id;
        UI_Manager.TriggerAvatarButtonEvent();
        CustomizationManager.instance.UpdateAvatar(id);
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArtBoard2ScreenFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }

    public void LoadArtBoard2ScreenFeet()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.feet);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }

    public void LoadArtBoard2Screen()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.torso);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }

    public void LoadArtBoardSave()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave);
    }

    #endregion

    #endregion
}
