using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountSettingsScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject wannaLoginPrefab;
    [SerializeField] private GameObject oldNewPasswordPrefab;
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

    public void LogOut()
    {
        manager.NextScreen(wannaLoginPrefab, true, true);
    }

    public void LoadOldNewPasswordScreen()
    {
        manager.NextScreen(oldNewPasswordPrefab);
    }

    #endregion

    #endregion
}
