using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgotPasswordScript : MonoBehaviour
{
    #region variables

    [SerializeField] private GameObject confirmPasswordPrefab;
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

    public void LoadConfirmPasswordScreen()
    {
        manager.NextScreen(confirmPasswordPrefab);
    }

    public void LoadSignupScreen()
    {
        manager.NextScreen(signupPrefab);
    }

    #endregion

    #endregion
}
