using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject viewProfilePrefab;
    [SerializeField] private GameObject forgotPasswordPrefab;
    [SerializeField] private GameObject signupPrefab;
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

    public void LoadSignupScreen()
    {
        manager.NextScreen(signupPrefab);
    }
    public void LoadViewProfileScreen()
    {
        manager.NextScreen(viewProfilePrefab);
    }
    public void LoadForgotPasswordScreen()
    {
        manager.NextScreen(forgotPasswordPrefab);
    }
    public void DelayedLoadViewProfile()
    {
        manager.MakeLoader();
        Invoke(nameof(LoadViewProfileScreen), 2);
    }
    #endregion

    #endregion

}
