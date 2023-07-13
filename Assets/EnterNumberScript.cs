using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNumberScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject setPasswordPrefab;
    #endregion

    #region functions
    #region private-functions

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadPasswordScreen()
    {
        UI_Manager.instance.NextScreen(setPasswordPrefab);
    }

    #endregion

    #endregion
}
