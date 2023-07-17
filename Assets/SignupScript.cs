using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignupScript : MonoBehaviour
{
    #region variables

    #region public-variables

    public UI_Manager.PlayerInfo playerInfo;

    #endregion

    #region private-variables

    [SerializeField] private Button emailSignup;
    [SerializeField] private Button phoneSignup;
    [SerializeField] private Button walletSignup;
    
    #endregion
    
    #endregion

    #region functions

    #region private-functions

    private UI_Manager.PlayerInfo CreateNewPlayer()
    { 
        playerInfo = new UI_Manager.PlayerInfo();
        return playerInfo;
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadSetPasswordScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.H_SetPasswordScreen);
    }

    public void LoadNumberScreen()
    {
        playerInfo = CreateNewPlayer();
        UI_Manager.instance.NextScreen(UI_Manager.Screen.E_EnterNumberScreen);
    }
    public void LoadEmailScreen()
    {
        playerInfo = CreateNewPlayer();
        UI_Manager.instance.NextScreen(UI_Manager.Screen.F_EnterEmailScreen);
    }
    public void LoadLoginScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.C_LoginScreen);
    }

    public void DelayedLoadViewProfile()
    {
        UI_Manager.instance.MakeLoader();
        playerInfo = CreateNewPlayer();
        playerInfo.email = "WALLET-" + (UI_Manager.instance.playerInfos.Count - 1).ToString();
        playerInfo.phoneNumber = "WALLET-" + (UI_Manager.instance.playerInfos.Count - 1).ToString();
        Invoke(nameof(LoadSetPasswordScreen), 2);
    }


    #endregion

    #endregion
}
