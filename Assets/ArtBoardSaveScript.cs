using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoardSaveScript : MonoBehaviour
{
    #region variables

    #endregion

    #region functions
      
    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadViewProfile()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.front);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ViewProfileScreen,true);
        UI_Manager.instance.UpdateJson();
        Destroy(gameObject);
    }
    public void LoadArtBoardFace()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    #endregion

    #endregion
}
