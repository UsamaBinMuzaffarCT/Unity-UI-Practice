using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WannaLoginScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject loginScreenPrefab;
    [SerializeField] private GameObject signupScreenPrefab;
    [SerializeField] private UI_Manager manager;
    #endregion

    #region functions

    private void Awake()
    {
        manager = GameObject.Find("UI Manager").GetComponent<UI_Manager>();
    }

    public void LoadLoginScreen()
    {
        manager.NextScreen(loginScreenPrefab);
    }
    public void LoadSignupScreen()
    {
        manager.NextScreen(signupScreenPrefab);
    }

    #endregion
}
