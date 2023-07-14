using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoardWishlistScript : MonoBehaviour
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
        UI_Manager.instance.NextScreen(UI_Manager.Screen.Z_ArtBoardFace);
    }

    public void LoadArtBoardSave()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ZB_ArtBoardSave);
    }

    #endregion

    #endregion
}
