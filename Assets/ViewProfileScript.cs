using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ViewProfileScript : MonoBehaviour
{
    #region variables
    
    [SerializeField] Image photo;
    [SerializeField] GameObject photoContainer;
    [SerializeField] TMP_Text username;
    private string imagesFolderPath;
    
    #endregion

    #region functions

    #region public-functions

    #endregion

    #region private-functions

    // Unity Functions
    private void Awake()
    {
        CustomizationManager.instance.MoveCameraTo(CustomizationManager.CameraPositionNames.Front);
        imagesFolderPath = UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].imageFolder;
    }

    private void Start()
    {
        UpdateProfileAndImages();
    }

    // Non-Unity Functions

    private bool CheckExtention(String input)
    {
        String result = input.Substring(input.Length - 4);
        if(result == "meta")
        {
            return false;
        }
        return true;
    }

    private void ClearScrollView()
    {
        foreach(Transform child in  photoContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private List<string> GetImagePaths()
    {
        List<string> imagePaths = new List<string>();
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/" + imagesFolderPath);
        FileInfo[] info = dir.GetFiles("*.*");

        foreach (FileInfo f in info)
        {
            if (CheckExtention(f.FullName))
            {
                imagePaths.Add(imagesFolderPath + "/" + f.Name.ToString().Substring(0, f.Name.ToString().Length - 4));
            }
        }
        return imagePaths;
    }

    private void UpdateProfileAndImages()
    {
        AssetDatabase.Refresh();
        ClearScrollView();
        CustomizationManager.instance.UpdateAvatar(UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].currentAvatarID);
        username.text = UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].name;
        List<string> imagePaths = GetImagePaths();
        foreach (string imagePath in imagePaths)
        {
            Image loadedPhoto = Instantiate(photo);
            loadedPhoto.transform.SetParent(photoContainer.transform);
            Debug.Log(imagePath);
            loadedPhoto.sprite = Resources.Load<Sprite>(imagePath);
        }
    }
    
    private void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        if (File.Exists(sourceFilePath))
        {
            File.Copy(sourceFilePath, destinationFilePath, true);
            Debug.Log("Image copied successfully!");
        }
        else
        {
            Debug.LogError("Source image file does not exist!");
        }
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadEditProfileScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.EditProfileScreen);
    }

    public void LoadSettingsScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.SettingsScreen);
    }
    public void LoadArtBoardScreen()
    {
        UI_Manager.instance.NextScreen(UI_Manager.Screen.ArtBoard1);
    }

    public void AddPhoto()
    {
        string getPath = "";
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            getPath = path;
        }, "Add New Photo", mime: "image/*");
        List<string> imagePaths = GetImagePaths();
        CopyFile(getPath,"Assets\\Resources\\"+ UI_Manager.instance.playerInfos[UI_Manager.instance.currentUser].imageFolder+"\\image"+imagePaths.Count.ToString()+ Path.GetExtension(getPath));
        UpdateProfileAndImages();   
    }

    #endregion

    #endregion
}