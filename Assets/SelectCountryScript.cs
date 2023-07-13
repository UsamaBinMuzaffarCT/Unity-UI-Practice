using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCountryScript : MonoBehaviour
{
    #region variables

    [SerializeField] private GameObject viewProfilePrefab;
    
    #endregion

    #region functions

    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadViewProfileScreen()
    {
        UI_Manager.instance.NextScreen(viewProfilePrefab);
    }

    #endregion


    #endregion
}
