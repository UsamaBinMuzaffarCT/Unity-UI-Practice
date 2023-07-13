using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artboard1Script : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject artBoard2Prefab;
    #endregion

    #region functions
    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArtBoard2Screen()
    {
        UI_Manager.instance.NextScreen(artBoard2Prefab);
    }

    #endregion

    #endregion
}
