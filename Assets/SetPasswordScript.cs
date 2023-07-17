using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPasswordScript : MonoBehaviour
{
    #region variables

    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField confirmPassword;
    [SerializeField] private SignupScript signupScript;

    #endregion

    #region functions

    #region private-functions
    private void Awake()
    {
        signupScript = UI_Manager.instance.signupScript;
    }

    private bool CheckPasswords()
    {
        if(password.text == confirmPassword.text)
        {
            return true;
        }
        return false;
    }
    
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadOTPScreen()
    {
        if (CheckPasswords())
        {
            signupScript.playerInfo.password = password.text;
            UI_Manager.instance.NextScreen(UI_Manager.Screen.G_OTPScreen);
        }
        else
        {
            UI_Manager.instance.MakePopup("Passwords don't match");
        }
    }

    #endregion

    #endregion
}
