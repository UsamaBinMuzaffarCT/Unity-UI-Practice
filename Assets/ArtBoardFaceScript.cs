using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBoardFaceScript : MonoBehaviour
{
    #region variables

    #endregion

    #region functions

    #region public-functions

    public void Back()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.instance.prevPosition);
        UI_Manager.instance.Back();
    }

    #endregion

    #endregion
}
