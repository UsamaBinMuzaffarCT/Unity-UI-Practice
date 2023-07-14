using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignupScript : MonoBehaviour
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

    public void LoadSetPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.H_SetPasswordScreen);
    }

    public void LoadNumberScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.E_EnterNumberScreen);
    }
    public void LoadEmailScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.F_EnterEmailScreen);
    }
    public void LoadLoginScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.C_LoginScreen);
    }

    public void DelayedLoadViewProfile()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadSetPasswordScreen), 2);
    }


    #endregion

    #endregion
}
