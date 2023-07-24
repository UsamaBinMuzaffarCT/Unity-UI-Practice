using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TestPNG : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private RenderTexture renderTexture;
    private void CopyDefaultAvatar(RenderTexture renderTexture, string path)
    {
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        var bytes = texture.EncodeToPNG();
        File.WriteAllBytes(path + "/" + renderTexture.name + ".png", bytes);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CopyDefaultAvatar(renderTexture, "Assets/Resources/Test");
            AssetDatabase.Refresh();
        }
    }
}
