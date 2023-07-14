using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEmailScript : MonoBehaviour
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

    public void LoadPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.H_SetPasswordScreen);
    }

    #endregion

    #endregion
}
