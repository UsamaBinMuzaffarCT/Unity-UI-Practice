using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    #region variables

    #region public-variables
    
    public string email;

    #endregion

    #region private-variables

    [SerializeField] private TMP_InputField phoneOrEmail;
    [SerializeField] private TMP_InputField password;
    private List<UI_Manager.PlayerInfo> playerInfos;

    #endregion

    #endregion

    #region functions

    #region private-functions

    // Unity Functions

    private void Awake()
    {
        playerInfos = UI_Manager.instance.playerInfos;
    }

    // Non-Unity Functions

    private bool CheckLogin()
    {
        playerInfos = UI_Manager.instance.playerInfos;
        if (!(playerInfos.Count == 0))
        {
            for (int i = 0; i < playerInfos.Count; i++)
            {
                if (phoneOrEmail.text == playerInfos[i].phoneNumber ||
                    phoneOrEmail.text == playerInfos[i].email)
                {

                    if (password.text == playerInfos[i].password)
                    {
                        UI_Manager.instance.currentUser = i;
                        return true;
                    }
                }
            }
            UI_Manager.instance.MakePopup("Incorrect Email/Phone or Password");
        }
        else
        {
            UI_Manager.instance.MakePopup("No Users Yet");
        }
        return false;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.SignUpScreen);
    }
    public void LoadViewProfileScreen()
    {
        if (CheckLogin())
        {
            UI_Manager.instance.NextScreen(UI_Manager.Screen.ViewProfileScreen);
        }
    }
    public void LoadForgotPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ForgotPassScreen);
    }
    public void DelayedLoadViewProfile()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadViewProfileScreen), 2);
    }

    #endregion

    #endregion

}
