using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignupScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject phoneNumberPrefab;
    [SerializeField] private GameObject emailPrefab;
    [SerializeField] private GameObject walletPrefab;
    [SerializeField] private GameObject loginPrefab;
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

    public void LoadNumberScreen()
    {
        manager.NextScreen(phoneNumberPrefab);
    }
    public void LoadEmailScreen()
    {
        manager.NextScreen(emailPrefab);
    }
    public void LoadLoginScreen()
    {
        manager.NextScreen(loginPrefab);
    }



    #endregion

    #endregion
}
