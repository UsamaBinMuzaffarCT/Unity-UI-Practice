using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    #region variables
    public string email;
    [SerializeField] private TMP_InputField phoneOrEmail;
    [SerializeField] private TMP_InputField password;
    #endregion

    #region functions
    #region private-functions

    #endregion

    private bool CheckLogin()
    {
        if(!(UI_Manager.instance.playerInfos.Count == 0))
        {
            for(int i = 0; i < UI_Manager.instance.playerInfos.Count; i++)
            {
                if (phoneOrEmail.text == UI_Manager.instance.playerInfos[i].phoneNumber || 
                    phoneOrEmail.text == UI_Manager.instance.playerInfos[i].email)
                {

                    if (password.text == UI_Manager.instance.playerInfos[i].password)
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

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadSignupScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.D_SignUpScreen);
    }
    public void LoadViewProfileScreen()
    {
        if (CheckLogin())
        {
            UI_Manager.instance.NextScreen(UI_Manager.Screen.O_ViewProfileScreen);
        }
    }
    public void LoadForgotPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.K_ForgoPassScreen);
    }
    public void DelayedLoadViewProfile()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadViewProfileScreen), 2);
    }
    #endregion

    #endregion

}
