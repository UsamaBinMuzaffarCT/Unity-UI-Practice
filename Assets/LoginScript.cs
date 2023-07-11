using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject A;
    [SerializeField] private GameObject B;
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
        //manager.NextScreen();
    }
    public void LoadSignupScreen()
    {
        //manager.NextScreen();
    }

    #endregion

    #endregion

}
