using System.Collections;
using System.Collections.Generic;
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

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadPasswordScreen()
    {
        signupScript.playerInfo.phoneNumber = phoneNumber.text;
        //Debug.Log(signupScript.playerInfo.phoneNumber);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.H_SetPasswordScreen);
    }

    #endregion

    #endregion
}
