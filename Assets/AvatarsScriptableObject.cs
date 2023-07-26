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
    public GameObject avatar;
    public Sprite image;
    public List<CustomizationManager.Positions> cameraPositions;
}

