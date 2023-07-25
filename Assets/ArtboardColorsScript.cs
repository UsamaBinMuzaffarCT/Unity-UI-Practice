using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtboardColorsScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject colorPalette;
    [SerializeField] private GameObject colorContentZone;
    [SerializeField] private Color centerColor;
    [SerializeField] private int numColors = 24;
    [SerializeField] private List<Color> colors;
    #endregion

    #region functions

    #region private-functions
    
    private List<Color> ColorsInterpolation()
    {
        Color startColor = Color.white;
        Color endColor = Color.black;
        float stepSize = 1f / numColors;
        List<Color> intermediateColors = new List<Color>();
        for (int i = 0; i < numColors; i++) 
        { 
            float t = i * stepSize;
            Color intermediateColor;
            if(t < 0.5)
            {
                intermediateColor = Color.Lerp(startColor, centerColor, t * 2f);
            }
            else
            {
                intermediateColor = Color.Lerp(centerColor, endColor, (t - 0.5f) * 2f);
            }
            intermediateColor.a = 1f;
            intermediateColors.Add(intermediateColor);
        }
        return intermediateColors;
    }

    private void Awake()
    {
        colors = ColorsInterpolation();
        foreach(Color color in colors)
        {
            GameObject loaded = Instantiate(colorPalette);
            loaded.transform.SetParent(colorContentZone.transform, false);
            loaded.GetComponent<Image>().color = color;
        }
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }
    public void LoadArtBoardColorPanelScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardColorPanel);
    }
    public void LoadArtBoardSave()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardSave);
    }

    public void LoadArtBoardFace()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    #endregion

    #endregion
}
