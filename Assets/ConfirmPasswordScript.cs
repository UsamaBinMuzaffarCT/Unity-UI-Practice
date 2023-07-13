using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPasswordScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject loginPrefab;
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
        UI_Manager.instance.NextScreen(loginPrefab,true);
    }

    #endregion

    #endregion
}
