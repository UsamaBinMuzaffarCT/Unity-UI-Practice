using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OTPScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject enterNamePrefab;
    #endregion

    #region functions

    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadEnterNameScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.J_EnterNameScreen);
    }

    #endregion

    #endregion
}
