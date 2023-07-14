using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    #region variables

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
        UI_Manager.instance.NextScreen(UI_Manager.Screen.Q_AccountSettingsScreen);
    }

    #endregion

    #endregion
}
