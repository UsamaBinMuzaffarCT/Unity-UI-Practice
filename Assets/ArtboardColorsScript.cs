using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtboardColorsScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject artBoardColorPanelPrefab;
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
        UI_Manager.instance.NextScreen(artBoardColorPanelPrefab);
    }

    #endregion

    #endregion
}
