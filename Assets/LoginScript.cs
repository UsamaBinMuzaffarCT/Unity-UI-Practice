using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScript : MonoBehaviour
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

    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(/*signupPrefab*/UI_Manager.Screen.D_SignUpScreen);
    }
    public void LoadViewProfileScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.O_ViewProfileScreen);
    }
    public void LoadForgotPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.K_ForgoPassScreen);
    }
    public void DelayedLoadViewProfile()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadViewProfileScreen), 2);
    }
    #endregion

    #endregion

}
