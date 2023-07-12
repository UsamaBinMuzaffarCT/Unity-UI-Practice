using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewProfileScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject editProfilePrefab;
    [SerializeField] private GameObject settingPrefab;
    [SerializeField] private UI_Manager manager;
    #endregion

    #region functions
    #region private-functions

    private void Awake()
    {
        manager = GameObject.Find("UI Manager").GetComponent<UI_Manager>();
    }

    #endregion

    #region public-functions

    public void Back()
    {
        manager.Back();
    }

    public void LoadEditProfileScreen()
    {
        manager.NextScreen(editProfilePrefab);
    }

    public void LoadSettingsScreen()
    {
        Debug.Log("settings");
        manager.NextScreen(settingPrefab);
    }

    #endregion

    #endregion
}
