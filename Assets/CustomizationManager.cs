using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{

    #region enumerators

    public enum CameraPositionNames
    {
        Front,
        Face,
        Torso,
        Feet,
        FaceSide
    }

    #endregion

    #region variables

    #region public-variables

    public static CustomizationManager instance { get; private set; }
    public AvatarsScriptableObject avatars;
    public CameraPositions cameraPositions;
    public GameObject cameraView;

    #endregion

    #region private-variables

    [SerializeField] private GameObject avatarHolder;

    #endregion

    #endregion

    #region functions

    #region private-functions

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void DisableAllAvatars(int layer)
    {
        foreach(Transform child in avatarHolder.transform)
        {
            if(child.gameObject.layer == layer)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void ChangeChildrenLayer(GameObject gameObject, int layer)
    {
        gameObject.layer = layer;
        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.layer = layer;
        }
    }

    #endregion

    #region public-functions

    public void UpdateAvatar(int id)
    {
        GameObject loaded = Instantiate(avatars.avatars.Find(x => x.id == id).avatar);
        int layer = LayerMask.NameToLayer("Avatar");
        DisableAllAvatars(layer);
        ChangeChildrenLayer(loaded, layer);
        loaded.transform.SetParent(avatarHolder.transform);
        loaded.transform.rotation = Quaternion.Euler(0,180f,0);
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID = id;
    }

    public void MoveCameraTo(CameraPositionNames position)
    {
        cameraView.transform.position = cameraPositions.CameraPositionsList.Find(x => x.names == position).position;
    }

    #endregion

    #endregion

}
