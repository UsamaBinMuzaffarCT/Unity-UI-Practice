using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Artboard2Script : MonoBehaviour
{
    #region variables

    [SerializeField] private Image photo;
    [SerializeField] private GameObject photoContainer;
    private string itemsFolderPath;

    #endregion

    #region functions
    #region private-functions

    //Unity Functions

    private void Awake()
    {
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
    }

    public void LoadArtBoardColorsScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardColors);
    }
    public void LoadArtBoardColorPanelScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardColorPanel);
    }

    public void LoadArtBoard4()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard4);
    }

    public void LoadArtBoardFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace,add:false);
    }

    public void MoveCameraToTorso()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.torso);
    }

    public void MoveCameraToFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.face);
    }

    public void MoveCameraToFeet()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.feet);
    }

    public void LoadArtBoardSave()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave, add: false);
    }

    #endregion

    #endregion
}
