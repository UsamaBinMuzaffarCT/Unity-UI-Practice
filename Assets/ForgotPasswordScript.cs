using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgotPasswordScript : MonoBehaviour
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

    public void LoadConfirmPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.L_ConfirmPassScreen);
    }

    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.D_SignUpScreen);
    }

    #endregion

    #endregion
}
