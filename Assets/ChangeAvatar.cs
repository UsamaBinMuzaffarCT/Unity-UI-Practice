using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAvatar : MonoBehaviour
{


    #region functions

    private void Awake()
    {
        UpdateAvatar();
        UI_Manager.OnAvatarButtonClick += UpdateAvatar;
    }

    private void OnDestroy()
    {
        UI_Manager.OnAvatarButtonClick -= UpdateAvatar;
    }

    public void UpdateAvatar()
    {
        GetComponent<RawImage>().texture = Resources.Load<Texture>(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatar);
    }
    
    #endregion
}
