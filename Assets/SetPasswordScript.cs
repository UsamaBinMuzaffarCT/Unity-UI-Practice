using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPasswordScript : MonoBehaviour
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

    public void LoadOTPScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.G_OTPScreen);
    }

    #endregion

    #endregion
}
