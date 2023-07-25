using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WannaLoginScript : MonoBehaviour
{
    #region variables

    #endregion

    #region functions

    public void LoadLoginScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.LoginScreen);
    }
    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.SignUpScreen);
    }

    #endregion
}
