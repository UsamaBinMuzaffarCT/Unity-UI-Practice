using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldNewPassScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject loginPrefab;
    [SerializeField] private GameObject forgotPasswordPrefab;
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

    public void LoadLoginScreen()
    {
        manager.NextScreen(loginPrefab,true);
    }

    public void LoadForgotPasswordScreen()
    {
        manager.NextScreen(forgotPasswordPrefab);
    }

    public void DelayedLoadLoginScreen()
    {
        manager.MakeLoader();
        Invoke(nameof(LoadLoginScreen),2);
    }

    public void DelayedLoadForgotPasswordScreen()
    {
        manager.MakeLoader();
        Invoke(nameof(LoadForgotPasswordScreen), 2);
    }

    #endregion

    #endregion
}
