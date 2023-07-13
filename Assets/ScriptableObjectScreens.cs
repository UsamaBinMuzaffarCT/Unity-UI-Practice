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
        string[] info = Directory.GetFiles("Assets/Resources/Prefabs");
        List<string> list = new List<string>();
        for (int i = 0; i < info.Length; i+=2)
        {
            string name = Path.GetFileNameWithoutExtension(info[i]);
            list.Add(name);
        }
        list.Sort();
        foreach (string name in list)
        {
            Debug.Log(name);
        }


        screensArray = Resources.LoadAll<GameObject>("Prefabs");
        
    }
}
