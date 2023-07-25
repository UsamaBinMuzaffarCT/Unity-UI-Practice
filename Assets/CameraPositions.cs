using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraPostionsScriptable", menuName = "ScriptableObjects/CameraPostionsScriptable")]

public class CameraPositions : ScriptableObject
{
    public List<CameraPosition> CameraPositionsList;   
}

[Serializable]
public class CameraPosition
{
    public Vector3 position;
    public CustomizationManager.CameraPositionNames names;
}