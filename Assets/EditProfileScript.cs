using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditProfileScript : MonoBehaviour
{
    #region variables

    [SerializeField] private TMP_Text namePlaceholder;
    
    #endregion

    #region functions

    #region private-functions

    // Unity Functions

    private void Awake()
    {
        namePlaceholder.text = UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].name;
    }

    // Non-Unity Functions

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadViewProfileScreen()
    {

        UI_Manager.instance.NextScreen(UI_Manager.Screen.ViewProfileScreen,true);
    }

    public void LoadArdBoardScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard1);
    }

    #endregion

    #endregion
}
