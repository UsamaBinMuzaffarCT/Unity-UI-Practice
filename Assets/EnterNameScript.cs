using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class EnterNameScript : MonoBehaviour
{
    #region variables

    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private SignupScript signupScript;

    #endregion

    #region functions

    #region private-functions

    private void Awake()
    {
        signupScript = UI_Manager.instance.signupScript;
    }

    private bool CheckNames()
    {
        foreach(UI_Manager.PlayerInfo playerInfo in UI_Manager.instance.playerInfos)
        {
            if(playerInfo.name == nameField.text)
            {
                return false;
            }
        }
        return true;
    }

    private void ClearInputFields()
    {
        nameField.text = string.Empty;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadSelectCountryScreen()
    {
        if(CheckNames())
        {
            signupScript.playerInfo.name = nameField.text;
            UI_Manager.instance.NextScreen(UI_Manager.Screen.N_SelectCountryScreen);
            ClearInputFields();
        }
        else
        {
            UI_Manager.instance.MakePopup("Username Already Exists");
        }

    }

    #endregion

    #endregion
}
