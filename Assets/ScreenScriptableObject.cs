using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScreensLoadedProperly", menuName = "ScriptableObjects/ScreensLoadedProperly")]
public class ScreenScriptableObject : ScriptableObject
{
    public List<ScreenInfo> Screens;
}
[Serializable]
public class ScreenInfo
{
    public UI_Manager.Screen screen;
    public GameObject prefab;
}