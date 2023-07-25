using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAvatar : MonoBehaviour
{

    #region variables

    private RawImage rawImage;

    #endregion

    #region functions

    // Unity Functions

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
        UpdateAvatar();

        UI_Manager.OnAvatarButtonClick += UpdateAvatar;
    }

    private void OnDestroy()
    {
        UI_Manager.OnAvatarButtonClick -= UpdateAvatar;
    }

    // Non-Unity Functions

    public void UpdateAvatar()
    {
        //rawImage.texture = Resources.Load<Texture>("RenderTextures/" + UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatar);
    }
    
    #endregion
}
