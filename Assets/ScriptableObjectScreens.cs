using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ScreensLoaded", menuName = "ScriptableObjects/ScreensLoaded")]
public class ScriptableObjectScreens : ScriptableObject
{
    public GameObject[] screensArray;

    public void Load()
    {

        screensArray = Resources.LoadAll<GameObject>("Prefabs");

    }
}
