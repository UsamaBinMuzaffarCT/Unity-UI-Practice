using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{

    #region classes

    [Serializable]
    public class Positions
    {
        public Vector3 position;
        public PositionNames postionName;
    }

    #endregion

    #region enumerators

    public enum Customizer
    {
        Hair,
        Face,
        Clothes,
        Shoes
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Class
    {
        Human,
        Elf,
        Orc,
        Demon
    }

    public enum PositionNames
    {
        front,
        face,
        torso,
        feet
    }

    #endregion

    #region variables

    #region public-variables

    public static CustomizationManager instance { get; private set; }
    public AvatarsScriptableObject avatars;
    public PositionNames currentPosition;
    public PositionNames prevPosition;
    public Customizer customizer;

    #endregion

    #region private-variables
    
    [SerializeField] private GameObject avatarHolder;
    [SerializeField] private GameObject cameraView;
    [SerializeField] private float glideSpeed = 1.0f;
    private List<Positions> positions;

    #endregion

    #endregion

    #region coroutines

    private IEnumerator GlideCameraTo(Vector3 destination)
    {
        while(cameraView.transform.position != destination)
        {
            cameraView.transform.position = Vector3.MoveTowards(cameraView.transform.position, destination, glideSpeed * Time.deltaTime);
            yield return null;
        }
        
    }

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

    public void SetCustomizer(Customizer customizer)
    {
        this.customizer = customizer;
    }

    public void UpdateAvatar(int id, Gender gender, PositionNames positionName = PositionNames.front)
    {
        GameObject loaded;
        if (gender == Gender.Male)
        {
            loaded = Instantiate(avatars.avatars.Find(x => x.id == id).maleAvatar);
            positions = avatars.avatars.Find(x => x.id == id).maleCameraPositions;
        }
        else
        {
            loaded = Instantiate(avatars.avatars.Find(x => x.id == id).femaleAvatar);
            positions = avatars.avatars.Find(x => x.id == id).femaleCameraPositions;
        }
        int layer = LayerMask.NameToLayer("Avatar");
        DisableAllAvatars(layer);
        ChangeChildrenLayer(loaded, layer);
        loaded.transform.SetParent(avatarHolder.transform);
        loaded.transform.rotation = Quaternion.Euler(0,180f,0);
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID = id;
        MoveCameraTo(positionName);
    }

    public void MoveCameraTo(PositionNames postionName)
    {
        StartCoroutine(GlideCameraTo(positions.Find(x => x.postionName == postionName).position));
        currentPosition = postionName;
    }

    #endregion

    #endregion

}
