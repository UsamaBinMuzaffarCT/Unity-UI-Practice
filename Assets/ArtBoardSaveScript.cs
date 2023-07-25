using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoardSaveScript : MonoBehaviour
{
    #region variables
    private Vector3 prev;
    #endregion

    #region functions
    private void Awake()
    {
        prev = CustomizationManager.instance.cameraView.transform.position;
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.CameraPositionNames.Front);    
    }

    #region public-functions

    public void Back()
    {
        CustomizationManager.instance.cameraView.transform.position = prev;
        UI_Manager.instance.Back();
        Destroy(gameObject);
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
