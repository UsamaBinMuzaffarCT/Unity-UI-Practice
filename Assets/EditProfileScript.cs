using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditProfileScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject profileAvatarPrefab;
    #endregion

    #region functions

    #region private-functions
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadArdBoardScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.S_ArtBoard1);
    }

    #endregion

    #endregion
}
