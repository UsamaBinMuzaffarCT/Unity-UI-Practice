using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPasswordScript : MonoBehaviour
{
    #region variables

    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField confirmPassword;
    [SerializeField] private SignupScript signupScript;
    [SerializeField] private Button passwordHideButton;
    [SerializeField] private Button confirmPasswordHideButton;
    private bool showPass;
    private bool showConfirmPass;

    #endregion

    #region functions

    #region private-functions

    // Unity Functions

    private void Awake()
    {
        password.contentType = TMP_InputField.ContentType.Password;
        confirmPassword.contentType = TMP_InputField.ContentType.Password;
        showPass = showConfirmPass = false;
        signupScript = UI_Manager.instance.signupScript;
    }

    // Non-Unity Functions

    private void HidePassword(TMP_InputField password)
    {
        password.contentType = TMP_InputField.ContentType.Password;
    }

    private void ShowPassword(TMP_InputField password)
    {
        password.contentType = TMP_InputField.ContentType.Standard;
    }

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
        if(CheckSpaces(password))
        {
            return Regex.IsMatch(password, @"^[A-Za-z-0-9_@$+()[\]\s]+$", RegexOptions.None);
        }
        return false;
    }

    private bool CheckPasswords()
    {   
        if(password.text == confirmPassword.text)
        {
            return true;
        }
        return false;
    }

    private void ClearInputFields()
    {
        password.text = string.Empty;
        confirmPassword.text = string.Empty;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
        Destroy(gameObject);
    }

    public void LoadOTPScreen()
    {
        if (CheckPasswords())
        {
            if(IsPasswordValid(password.text) && password.text.Length>=8)
            {
                signupScript.playerInfo.password = password.text;
                UI_Manager.instance.NextScreen(UI_Manager.Screen.OTPScreen);
                ClearInputFields();
            }
            else
            {
                UI_Manager.instance.MakePopup("Invalid password\n- Alpha numeric\n- Use characters '$,@,_,-,.,(,),[,],white_space'");
            }
        }
        else
        {
            UI_Manager.instance.MakePopup("Passwords don't match");
        }
    }

    public void TogglePassword()
    {
        if(showPass)
        {
            ShowPassword(password);
            showPass = false;
        }
        else
        {
            HidePassword(password);
            showPass = true;
        }
    }

    public void ToggleConfirmPassword()
    {
        if (showConfirmPass)
        {
            ShowPassword(confirmPassword);
            showConfirmPass = false;
        }
        else
        {
            HidePassword(confirmPassword);
            showConfirmPass = true;
        }
    }

    #endregion

    #endregion
}
