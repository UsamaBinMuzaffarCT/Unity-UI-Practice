using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraPositions", menuName = "ScriptableObjects/CameraPositionsScriptableObject")]
public class CameraPositions : ScriptableObject
{
    public List<Position> cameraPositions;
}

public class Position
{
    public Vector3 position;
    public CustomizationManager.PostionNames positionName;
}