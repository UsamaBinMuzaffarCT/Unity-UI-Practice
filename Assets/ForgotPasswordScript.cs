using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgotPasswordScript : MonoBehaviour
{
    #region variables

    [SerializeField] private GameObject confirmPasswordPrefab;
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

    public void LoadConfirmPasswordScreen()
    {
        UI_Manager.instance.NextScreen(confirmPasswordPrefab);
    }

    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(signupPrefab);
    }

    #endregion

    #endregion
}
