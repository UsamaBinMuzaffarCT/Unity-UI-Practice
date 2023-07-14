using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtboardColorsScript : MonoBehaviour
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
    public void LoadArtBoardColorPanelScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.X_ArtBoardColorPanel);
    }
    public void LoadArtBoardSave()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ZB_ArtBoardSave);
    }

    public void LoadArtBoardFace()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.Z_ArtBoardFace);
    }

    #endregion

    #endregion
}
