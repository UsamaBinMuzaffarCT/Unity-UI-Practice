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

    [Serializable]
    public class SpriteWithID
    {
        public int id;
        public Sprite sprite;
    }

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
    private GameObject loadedAvatar;
    private List<Positions> positions;
    private Coroutine coroutine = null;

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

    private void SetAvatarSkin()
    {
        foreach(Transform child in loadedAvatar.GetComponent<AvatarSkin>().skinHolder.transform)
        {
            if (child.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
        foreach (Transform child in loadedAvatar.GetComponent<AvatarSkin>().hairHolder.transform)
        {
            if (child.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
        foreach (Transform child in loadedAvatar.GetComponent<AvatarSkin>().outfitHolder.transform)
        {
            if (child.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarOutfit)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void ActivateItem(Transform item, int id)
    {
        if (item.gameObject.GetComponent<AvatarInfo>().id == id)
        {
            item.gameObject.SetActive(true);
        }
        else
        {
            item.gameObject.SetActive(false);
        }
    }

    #endregion

    #region public-functions

    public void UpdateSkinColor(Color color)
    {
        foreach (Transform child in loadedAvatar.GetComponent<AvatarSkin>().skinHolder.transform)
        {
            if (child.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin)
            {
                foreach (Material mat in child.gameObject.GetComponent<SkinnedMeshRenderer>().materials)
                {
                    mat.color = color;
                }
            }
        }
    }

    public void UpdateHairColor(Color color)
    {
        foreach(Transform child in loadedAvatar.GetComponent<AvatarSkin>().hairHolder.transform)
        {
            if (child.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin)
            {
                foreach (Material mat in child.gameObject.GetComponent<SkinnedMeshRenderer>().materials)
                {
                    mat.color = color;
                }
            }
        }
    }

    public void UpdateItem(int id)
    {
        if (customizer == Customizer.Hair || customizer == Customizer.Face)
        {
            UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin = id;
            foreach (Transform child in loadedAvatar.GetComponent<AvatarSkin>().skinHolder.transform)
            {
                ActivateItem(child, id);
            }
            foreach (Transform child in loadedAvatar.GetComponent<AvatarSkin>().hairHolder.transform)
            {
                ActivateItem(child, id);
            }
        }
        else
        {
            UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarOutfit = id;
            foreach (Transform child in loadedAvatar.GetComponent<AvatarSkin>().outfitHolder.transform)
            {
                ActivateItem(child, id);
            }

        }
    }

    public void SetCustomizer(Customizer customizer)
    {
        this.customizer = customizer;
    }

    public void UpdateAvatar(int id, Gender gender, PositionNames positionName = PositionNames.front)
    {
        Color color;
        int layer = LayerMask.NameToLayer("Avatar");
        if (gender == Gender.Male)
        {
            loadedAvatar = Instantiate(avatars.avatars.Find(x => x.id == id).maleAvatar);
            positions = avatars.avatars.Find(x => x.id == id).maleCameraPositions;
        }
        else
        {
            loadedAvatar = Instantiate(avatars.avatars.Find(x => x.id == id).femaleAvatar);
            positions = avatars.avatars.Find(x => x.id == id).femaleCameraPositions;
        }
        DisableAllAvatars(layer);
        ChangeChildrenLayer(loadedAvatar, layer);
        loadedAvatar.transform.SetParent(avatarHolder.transform);
        loadedAvatar.transform.rotation = Quaternion.Euler(0,180f,0);
        UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID = id;
        MoveCameraTo(positionName);
        SetAvatarSkin();
        UnityEngine.ColorUtility.TryParseHtmlString(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentSkinColor, out color);
        UpdateSkinColor(color);
        UnityEngine.ColorUtility.TryParseHtmlString(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentHairColor, out color);
        UpdateHairColor(color);
    }

    public void MoveCameraTo(PositionNames postionName)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(GlideCameraTo(positions.Find(x => x.postionName == postionName).position));
        currentPosition = postionName;
    }

    #endregion

    #endregion

}
