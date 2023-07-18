using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoardSaveScript : MonoBehaviour
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

    public void LoadViewProfile()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.O_ViewProfileScreen,true);
        Destroy(gameObject);
    }
    public void LoadArtBoardFace()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.Z_ArtBoardFace);
    }

    #endregion

    #endregion
}
