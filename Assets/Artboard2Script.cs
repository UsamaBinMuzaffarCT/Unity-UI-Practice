using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artboard2Script : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject artBoardColorsPrefab;
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

    public void LoadArtBoardColorsScreen()
    {
        UI_Manager.instance.NextScreen(artBoardColorsPrefab);
    }
    public void LoadArtBoardColorPanelScreen()
    {
        UI_Manager.instance.NextScreen(artBoardColorPanelPrefab);
    }

    #endregion

    #endregion
}
