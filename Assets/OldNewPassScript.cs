using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldNewPassScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject loginPrefab;
    [SerializeField] private GameObject forgotPasswordPrefab;
    #endregion

    #region functions

    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadLoginScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.C_LoginScreen,true);
    }

    public void LoadForgotPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.K_ForgoPassScreen);
    }

    public void DelayedLoadLoginScreen()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadLoginScreen),2);
    }

    public void DelayedLoadForgotPasswordScreen()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadForgotPasswordScreen), 2);
    }

    #endregion

    #endregion
}
