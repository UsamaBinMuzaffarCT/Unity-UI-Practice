using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AvatarsScriptableObject", menuName = "ScriptableObjects/AvatarsScriptableObject")]
public class AvatarsScriptableObject : ScriptableObject
{
    public List<Avatar> avatars;
}

[Serializable]
public class Avatar
{
    public int id;
    public CustomizationManager.Class Class;
    public GameObject maleAvatar;
    public GameObject femaleAvatar;
    public Sprite maleImage;
    public Sprite femaleImage;
    public List<CustomizationManager.Positions> maleCameraPositions;
    public List<CustomizationManager.Positions> femaleCameraPositions;
}

