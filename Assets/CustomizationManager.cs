using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void SetAvatarSkin(GameObject avatar)
    {
        foreach (Transform child2 in avatar.transform)
        {
            if (child2.name == "Skin" || child2.name == "Hair")
            {
                foreach (Transform child3 in child2.transform)
                {
                    if (child3.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin)
                    {
                        child3.gameObject.SetActive(true);
                    }
                    else
                    {
                        child3.gameObject.SetActive(false);
                    }
                }
            }
            if (child2.name == "Outfits")
            {
                foreach (Transform child3 in child2.transform)
                {
                    if (child3.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarOutfit)
                    {
                        child3.gameObject.SetActive(true);
                    }
                    else
                    {
                        child3.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    #endregion

    #region public-functions

    public void UpdateSkinColor(Color color)
    {
        int layer = LayerMask.NameToLayer("Avatar");
        foreach (Transform child in avatarHolder.transform)
        {
            if(child.gameObject.layer == layer)
            {
                foreach (Transform item in child)
                {
                    if(item.transform.name == "Skin")
                    {
                        foreach (Transform item1 in item)
                        {
                            if(item1.gameObject.GetComponent<AvatarInfo>().id == UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin)
                            {
                                foreach(Material mat in item1.gameObject.GetComponent<SkinnedMeshRenderer>().materials)
                                {
                                    mat.color = color;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void UpdateItem(int id)
    {
        int layer = LayerMask.NameToLayer("Avatar");
        foreach (Transform child in avatarHolder.transform)
        {
            if(child.gameObject.layer == layer)
            {
                if(customizer == Customizer.Hair || customizer == Customizer.Face)
                {
                    foreach (Transform child2 in child.transform)
                    {
                        if (child2.name == "Skin" ||  child2.name == "Hair")
                        {
                            foreach(Transform child3 in child2.transform)
                            {
                                if(child3.gameObject.GetComponent<AvatarInfo>().id == id)
                                {
                                    child3.gameObject.SetActive(true);
                                    UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarSkin = id;
                                }
                                else
                                {
                                    child3.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Transform child2 in child.transform)
                    {
                        if (child2.name == "Outfits")
                        {
                            foreach (Transform child3 in child2.transform)
                            {
                                if (child3.gameObject.GetComponent<AvatarInfo>().id == id)
                                {
                                    child3.gameObject.SetActive(true);
                                    UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarOutfit = id;
                                }
                                else
                                {
                                    child3.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

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
        SetAvatarSkin(loaded);
        Color color;
        UnityEngine.ColorUtility.TryParseHtmlString(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentSkinColor, out color);
        UpdateSkinColor(color);
    }

    public void MoveCameraTo(PositionNames postionName)
    {
        StartCoroutine(GlideCameraTo(positions.Find(x => x.postionName == postionName).position));
        currentPosition = postionName;
    }

    #endregion

    #endregion

}
