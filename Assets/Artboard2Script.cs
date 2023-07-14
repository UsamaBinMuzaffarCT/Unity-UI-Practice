using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artboard2Script : MonoBehaviour
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

    public void LoadArtBoardColorsScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.Y_ArtBoardColors);
    }
    public void LoadArtBoardColorPanelScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.X_ArtBoardColorPanel);
    }

    public void LoadArtBoard4()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.V_ArtBoard4);
    }

    public void LoadArtBoardFace()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.Z_ArtBoardFace);
    }

    public void LoadArtBoardSave()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ZB_ArtBoardSave);
    }

    #endregion

    #endregion
}
