using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class EnterNumberScript : MonoBehaviour
{
    #region variables

    [SerializeField] private TMP_InputField phoneNumber;
    [SerializeField] private SignupScript signupScript;

    #endregion

    #region functions
    #region private-functions
    private void Awake()
    {
        signupScript = UI_Manager.instance.signupScript;
    }

    private bool IsValidPhoneNumber(string number)
    {
        return Regex.IsMatch(number, @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{6}$", RegexOptions.IgnoreCase);
    }

    private bool ExistingPhoneNumber(string number)
    {
        foreach (UI_Manager.PlayerInfo playerInfo in UI_Manager.instance.playerInfos)
        {
            if (number == playerInfo.phoneNumber)
            {
                return false;
            }
        }
        return true;
    }

    private void ClearInputFields()
    {
        phoneNumber.text = string.Empty;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadPasswordScreen()
    {
        if (IsValidPhoneNumber(phoneNumber.text))
        {
            if (ExistingPhoneNumber(phoneNumber.text))
            {
                signupScript.playerInfo.email = phoneNumber.text;
                UI_Manager.instance.NextScreen(UI_Manager.Screen.H_SetPasswordScreen);
                ClearInputFields();
            }
            else
            {
                UI_Manager.instance.MakePopup("Phone number already in use");
            }
        }
        else
        {
            UI_Manager.instance.MakePopup("Invalid Phone Number");
        }
    }

    #endregion

    #endregion
}
