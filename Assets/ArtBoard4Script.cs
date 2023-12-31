using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoard4Script : MonoBehaviour
{
    #region variables

    #endregion

    #region functions

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArtBoardWishlist()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardWishlist);
    }
    public void LoadArtBoardFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    public void LoadArtBoard5()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard5);
    }

    public void LoadArtBoardSave()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave);
    }

    #endregion

    #endregion
}
