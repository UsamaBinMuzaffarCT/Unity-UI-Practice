using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewProfileScript : MonoBehaviour
{
    #region variables
    [SerializeField] Image photo;
    [SerializeField] GameObject photoContainer;
    #endregion

    #region functions

    #region private-functions
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