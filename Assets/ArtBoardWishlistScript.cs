using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoardWishlistScript : MonoBehaviour
{
    #region variables

    #endregion

    #region functions

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArtBoardFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    public void LoadArtBoardSave()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave);
    }

    public void LoadArtBoard2ScreenFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }

    public void LoadArtBoard2ScreenFeet()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.feet);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }

    public void LoadArtBoard2Screen()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.torso);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard2);
    }


    #endregion

    #endregion
}
