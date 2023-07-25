using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;

public class EnterEmailScript : MonoBehaviour
{
    #region variables

    [SerializeField] private TMP_InputField email;
    [SerializeField] private SignupScript signupScript;

    #endregion

    #region functions
    #region private-functions

    private void Awake()
    {
        signupScript = UI_Manager.instance.signupScript;
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.+-]+\.(com|org|co\.pk|edu\.pk|gov\.pk)$", RegexOptions.IgnoreCase);
    }

    private void ClearInputFields()
    {
        email.text = string.Empty;
    }

    private bool ExistingEmail(string email)
    {
        foreach (UI_Manager.PlayerInfo playerInfo in UI_Manager.instance.playerInfos)
        {
            if(email == playerInfo.email)
            {
                return false;
            }
        }
        return true;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
        Destroy(gameObject);
    }

    public void LoadPasswordScreen()
    {
        if (IsValidEmail(email.text))
        {
            if (ExistingEmail(email.text))
            {
                signupScript.playerInfo.email = email.text;
                UI_Manager.instance.NextScreen(UI_Manager.Screen.SetPasswordScreen);
                ClearInputFields();
            }
            else
            {
                UI_Manager.instance.MakePopup("Email already in use");
            }
        }
        else
        {
            UI_Manager.instance.MakePopup("Invalid Email");
        }
    }

    #endregion

    #endregion
}
