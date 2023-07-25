using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForgotPasswordScript : MonoBehaviour
{
    #region variables

    [SerializeField] TMP_InputField inputField;

    #endregion

    #region functions

    #region private-functions

    private bool CheckAndSetUser()
    {
        for(int i = 0; i < UI_Manager.instance.playerInfos.Count; i++)
        {
            if(inputField.text == UI_Manager.instance.playerInfos[i].email ||
                inputField.text == UI_Manager.instance.playerInfos[i].phoneNumber)
            {
                if(inputField.text == "")
                {
                    return false;
                }
                UI_Manager.instance.currentUser = i;
                return true;
            }
        }
        return false;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadConfirmPasswordScreen()
    {
        if (CheckAndSetUser())
        {
            UI_Manager.instance.NextScreen(UI_Manager.Screen.ConfirmPassScreen);
        }
        else
        {
            UI_Manager.instance.MakePopup("Account doesn't exist");
        }
    }

    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.SignUpScreen);
    }

    #endregion

    #endregion
}
