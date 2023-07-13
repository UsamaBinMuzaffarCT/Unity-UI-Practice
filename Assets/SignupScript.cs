using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignupScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject phoneNumberPrefab;
    [SerializeField] private GameObject emailPrefab;
    [SerializeField] private GameObject setPasswordPrefab;
    [SerializeField] private GameObject loginPrefab;
    #endregion

    #region functions

    #region private-functions

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadSetPasswordScreen()
    {
        UI_Manager.instance.NextScreen(setPasswordPrefab);
    }

    public void LoadNumberScreen()
    {
        UI_Manager.instance.NextScreen(phoneNumberPrefab);
    }
    public void LoadEmailScreen()
    {
        UI_Manager.instance.NextScreen(emailPrefab);
    }
    public void LoadLoginScreen()
    {
        UI_Manager.instance.NextScreen(loginPrefab);
    }

    public void DelayedLoadViewProfile()
    {
        UI_Manager.instance.MakeLoader();
        Invoke(nameof(LoadSetPasswordScreen), 2);
    }


    #endregion

    #endregion
}
