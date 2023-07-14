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
        UI_Manager.instance.NextScreen(UI_Manager.Screen.C_LoginScreen);
    }
    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.D_SignUpScreen);
    }

    #endregion
}
