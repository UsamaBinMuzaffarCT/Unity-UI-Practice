using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenParent : MonoBehaviour
{
    #region variables
    [SerializeField] protected UI_Manager manager;
    #endregion

    #region functions

    #region protected-functions

    #endregion

    #region public-functions

    public void Back()
    {
        manager.Back();
    }

    #endregion

    #endregion
}
