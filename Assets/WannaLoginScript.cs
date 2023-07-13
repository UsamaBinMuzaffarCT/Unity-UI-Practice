using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WannaLoginScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject loginScreenPrefab;
    [SerializeField] private GameObject signupScreenPrefab;
    #endregion

    #region functions

    public void LoadLoginScreen()
    {
        UI_Manager.instance.NextScreen(loginScreenPrefab);
    }
    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(signupScreenPrefab);
    }

    #endregion
}
