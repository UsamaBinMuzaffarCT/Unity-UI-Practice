using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewProfileScript : MonoBehaviour
{
    #region variables
    [SerializeField] Image photo;
    [SerializeField] GameObject photoContainer;
    [SerializeField] TMP_Text username;
    #endregion

    #region functions

    #region public-functions

    public void CallUpdate()
    {
        UpdateProfile();
    }

    #endregion

    #region private-functions

    private bool CheckExtention(String input)
    {
        String result = input.Substring(input.Length - 4);
        if(result == "meta")
        {
            return false;
        }
        return true;
    }

    private void ClearScrollView()
    {
        foreach(Transform child in  photoContainer.transform)
        {
            Destroy(child);
        }
    }

    private void UpdateProfile()
    {
        ClearScrollView();   
        username.text = UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].name;
        List<string> imagePaths = new List<string>();
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/" + UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].imageFolder);
        FileInfo[] info = dir.GetFiles("*.*");

        foreach (FileInfo f in info)
        {
            if (CheckExtention(f.FullName))
            {
                imagePaths.Add(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].imageFolder + "/" + f.Name.ToString().Substring(0, f.Name.ToString().Length - 4));
            }
        }

        foreach (string imagePath in imagePaths)
        {
            Image loadedPhoto = Instantiate(photo);
            loadedPhoto.transform.SetParent(photoContainer.transform);
            Debug.Log(imagePath);
            loadedPhoto.sprite = Resources.Load<Sprite>(imagePath);
        }
    }

    private void Awake()
    {
        UpdateProfile();
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadEditProfileScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.R_EditProfileScreen);
    }

    public void LoadSettingsScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.P_SettingsScreen);
    }
    public void LoadArtBoardScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.S_ArtBoard1);
    }

    public void AddPhoto()
    {
        Instantiate(photo).transform.SetParent(photoContainer.transform);
    }

    #endregion

    #endregion
}


[Serializable]
public class Stats
{

}