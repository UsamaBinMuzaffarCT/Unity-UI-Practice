using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artboard1Script : MonoBehaviour
{
    #region variables

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
        UI_Manager.instance.NextScreen(UI_Manager.Screen.T_ArtBoard2);
    }

    public void LoadArtBoardSave()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ZB_ArtBoardSave);
    }

    #endregion

    #endregion
}
