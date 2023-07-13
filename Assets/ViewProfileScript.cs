using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewProfileScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject editProfilePrefab;
    [SerializeField] private GameObject settingPrefab;
    [SerializeField] private GameObject ardBoard1Prefab;
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
        UI_Manager.instance.NextScreen(editProfilePrefab);
    }

    public void LoadSettingsScreen()
    {
        UI_Manager.instance.NextScreen(settingPrefab);
    }
    public void LoadArtBoardScreen()
    {
        UI_Manager.instance.NextScreen(ardBoard1Prefab);
    }

    #endregion

    #endregion
}
