using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountSettingsScript : MonoBehaviour
{
    #region variables

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
        UI_Manager.instance.NextScreen(UI_Manager.Screen.B_WannaLoginScreen, true, true);
    }

    public void LoadOldNewPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.M_OldNewPassScreen);
    }

    #endregion

    #endregion
}
