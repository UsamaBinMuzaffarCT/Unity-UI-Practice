using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoard5Script : MonoBehaviour
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
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    public void LoadArtBoardSave()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave);
    }

    public void MoveCameraToTorso()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.torso);
    }

    public void MoveCameraToFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.face);
    }

    public void MoveCameraToFeet()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PostionNames.feet);
    }

    #endregion

    #endregion
}
