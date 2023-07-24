using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class OldNewPassScript : MonoBehaviour
{
    #region variables
    [SerializeField] private TMP_InputField oldPassword;
    [SerializeField] private TMP_InputField newPassword;
    [SerializeField] private TMP_InputField confirmNewPassword;
    #endregion

    #region functions

    #region private-functions

    private bool CheckSpaces(string text)
    {
        char firstChar = text[0];
        foreach (char c in text)
        {
            if (c != firstChar)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsPasswordValid(string password)
    {
        if (CheckSpaces(password))
        {
            return Regex.IsMatch(password, @"^[A-Za-z-0-9_@$+()[\]\s]+$", RegexOptions.None);
        }
        return false;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadLoginScreen()
    {
        if(oldPassword.text == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].password)
        {
            if(newPassword.text == confirmNewPassword.text)
            {
                if (IsPasswordValid(newPassword.text))
                {
                    if(newPassword.text.Length >= 8)
                    {
                        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].password = newPassword.text;
                        UI_Manager.instance.UpdateJson();
                        UI_Manager.instance.currentUser = -1;
                        UI_Manager.instance.NextScreen(UI_Manager.Screen.C_LoginScreen, true);
                    }
                    else
                    {
                        UI_Manager.instance.MakePopup("Password is too short");
                    }
                }
                else
                {
                    UI_Manager.instance.MakePopup("Invalid password\n- Alpha numeric\n- Use characters '$,@,_,-,.,(,),[,],white_space'");
                }
            }
            else
            {
                UI_Manager.instance.MakePopup("Passwords do not match");
            }
        }
        else
        {
            UI_Manager.instance.MakePopup("Old password is incorrect");
        }
    }

    public void LoadForgotPasswordScreen()
    {
        UI_Manager.instance.currentUser = -1;
        UI_Manager.instance.NextScreen(UI_Manager.Screen.K_ForgoPassScreen,true);
    }

    public void DelayedLoadLoginScreen()
    {
        LoadLoginScreen();
    }

    public void DelayedLoadForgotPasswordScreen()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadForgotPasswordScreen), 2);
    }

    #endregion

    #endregion
}
