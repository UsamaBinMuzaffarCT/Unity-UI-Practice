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
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ViewProfileScreen,true);
        UI_Manager.instance.UpdateJson();
        Destroy(gameObject);
    }
    public void LoadArtBoardFace()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    #endregion

    #endregion
}
