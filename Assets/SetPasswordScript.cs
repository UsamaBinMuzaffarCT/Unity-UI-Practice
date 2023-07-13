using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPasswordScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject OTPPrefab;
    #endregion

    #region functions

    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadOTPScreen()
    {
        UI_Manager.instance.NextScreen(OTPPrefab);
    }

    #endregion

    #endregion
}
