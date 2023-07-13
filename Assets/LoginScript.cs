using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject viewProfilePrefab;
    [SerializeField] private GameObject forgotPasswordPrefab;
    [SerializeField] private GameObject signupPrefab;
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
        UI_Manager.instance.NextScreen(signupPrefab);
    }
    public void LoadViewProfileScreen()
    {
        UI_Manager.instance.NextScreen(viewProfilePrefab);
    }
    public void LoadForgotPasswordScreen()
    {
        UI_Manager.instance.NextScreen(forgotPasswordPrefab);
    }
    public void DelayedLoadViewProfile()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadViewProfileScreen), 2);
    }
    #endregion

    #endregion

}
