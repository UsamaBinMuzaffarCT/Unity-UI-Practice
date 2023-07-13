using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject accountSettingsPrefab;
    #endregion

    #region functions

    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadaccountSettingsScreen()
    {
        UI_Manager.instance.NextScreen(accountSettingsPrefab);
    }

    #endregion

    #endregion
}
