using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountSettingsScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject wannaLoginPrefab;
    [SerializeField] private GameObject oldNewPasswordPrefab;
    #endregion

    #region functions
    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LogOut()
    {
        UI_Manager.instance.NextScreen(wannaLoginPrefab, true, true);
    }

    public void LoadOldNewPasswordScreen()
    {
        UI_Manager.instance.NextScreen(oldNewPasswordPrefab);
    }

    #endregion

    #endregion
}
