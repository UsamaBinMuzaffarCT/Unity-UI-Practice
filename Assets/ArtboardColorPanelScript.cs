using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtboardColorPanelScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject artBoardColorsPrefab;
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
        UI_Manager.instance.NextScreen(artBoardColorsPrefab);
    }

    #endregion

    #endregion
}
