using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmPasswordScript : MonoBehaviour
{
    #region variables

    [SerializeField] TMP_Text username;
    [SerializeField] TMP_InputField newPassword;
    [SerializeField] TMP_InputField confirmPassword;

    #endregion

    #region functions

    #region private-functions

    private void Awake()
    {
        username.text = UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].name;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadWannaLoginScreen()
    {
        if(newPassword.text == confirmPassword.text)
        {
            UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].password = newPassword.text;
            UI_Manager.instance.currentUser = -1;
            UI_Manager.instance.UpdateJson();
            UI_Manager.instance.NextScreen(UI_Manager.Screen.LoginScreen, true);
            Destroy(gameObject);
        }
        else
        {
            UI_Manager.instance.MakePopup("Passwords don't match");
        }
    }

    #endregion

    #endregion
}
