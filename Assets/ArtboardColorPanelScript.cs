using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtboardColorPanelScript : MonoBehaviour
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

    public void LoadArtBoardFace() 
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    public void LoadArtBoardColorsScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardColors);
    }

    #endregion

    #endregion
}
