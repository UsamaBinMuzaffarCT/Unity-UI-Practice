using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadSelectCountryScreen()
    {
        signupScript.playerInfo.name = nameField.text;
        UI_Manager.instance.NextScreen(UI_Manager.Screen.N_SelectCountryScreen);
    }

    #endregion

    #endregion
}
