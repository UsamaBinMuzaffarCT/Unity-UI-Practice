using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtboardColorPanelScript : MonoBehaviour
{
    #region variables

    [SerializeField] private Slider slider;
    [SerializeField] private Color color;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text colorHexCode;

    #endregion

    #region functions

    #region private-functions

    // Unity Functions

    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(slider.value);
    }


    private void OnSliderValueChanged(float value)
    {
        Debug.Log(value);
        float hue = value;
        color = Color.HSVToRGB(hue, 1f, 1f);
        image.color = color;
        image.GetComponentInChildren<TMP_Text>().color = Color.white;
        colorHexCode.text = ColorUtility.ToHtmlStringRGB(color);
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentHairColor = "#" + ColorUtility.ToHtmlStringRGB(color);
        CustomizationManager.instance.UpdateHairColor(color);
    }

    #endregion

    #region public-functions

    public void ResetToDefaultHairColor()
    {
        Color newColor = Color.white;
        image.color = newColor;
        image.GetComponentInChildren<TMP_Text>().color = Color.black;
        colorHexCode.text = ColorUtility.ToHtmlStringRGB(newColor);
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentHairColor = "#" + ColorUtility.ToHtmlStringRGB(newColor);
        CustomizationManager.instance.UpdateHairColor(newColor);
    }

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArtBoardFace() 
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardFace);
    }

    public void LoadArtBoardColorsScreen()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.PositionNames.face);
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoardColors);
    }

    #endregion

    #endregion
}
