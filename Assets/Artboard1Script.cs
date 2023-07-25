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

    private void ClearScrollView()
    {
        foreach (Transform child in photoContainer.transform)
        {
            Destroy(child);
        }
    }

    private void UpdateProfile()
    {
        ClearScrollView();
        List<string> avatarPaths = new List<string>();
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/" + UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].avatarFolder);
        FileInfo[] info = dir.GetFiles("*.*");

        foreach (FileInfo f in info)
        {
            if (CheckExtention(f.FullName))
            {
                avatarPaths.Add(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].avatarFolder + "/" + f.Name.ToString().Substring(0, f.Name.ToString().Length - 4));
            }
        }

        foreach (string avatarPath in avatarPaths)
        {
            Image loadedPhoto = Instantiate(photo);
            loadedPhoto.transform.SetParent(photoContainer.transform);
            loadedPhoto.sprite = Resources.Load<Sprite>(avatarPath);
            loadedPhoto.gameObject.transform.GetComponent<Button>().onClick.AddListener(() => UpdateCurrentAssetPath(loadedPhoto.sprite.name));
        }
    }

    private void UpdateCurrentAssetPath(string name)
    {
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatar = name;
        UI_Manager.RaiseButtonClickEvent();
    }

    private void Start()
    {
        UpdateProfile();
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArtBoard2Screen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }

    public void LoadArtBoardSave()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave);
    }

    #endregion

    #endregion
}
