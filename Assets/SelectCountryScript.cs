using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System;

public class SelectCountryScript : MonoBehaviour
{

    #region classes

    [Serializable]
    private class CountryInfo
    {
        public string countryName;
        public string countryCode;
        public string languageCode;
    }

    #endregion

    #region variables

    [SerializeField] private GameObject countryButtonPrefab;
    [SerializeField] private GameObject scrollViewContent;
    [SerializeField] private SignupScript signupScript;
    [SerializeField] private Button cancelButton;

    #endregion

    #region functions

    #region private-functions

    private void Awake()
    {
        cancelButton.onClick.AddListener(LoadViewProfileScreen);
        signupScript = UI_Manager.instance.signupScript;
        string jsonCountryInfo = "";
        using (StreamReader reader = new StreamReader("Assets/JSON/CountryData.json"))
        {
            jsonCountryInfo = reader.ReadToEnd();
        }
        List<CountryInfo>countryInfos = new List<CountryInfo>();
        countryInfos = JsonConvert.DeserializeObject<List<CountryInfo>>(jsonCountryInfo);
        Debug.Log("Countries: " + countryInfos.Count);
        foreach(CountryInfo countryInfo in countryInfos)
        {
            GameObject loaded = Instantiate(countryButtonPrefab);
            loaded.GetComponent<Button>().onClick.AddListener(LoadViewProfileScreen);
            loaded.GetComponent<CounrtyButton>().SetCountryCode(countryInfo.countryCode);
            loaded.GetComponent<CounrtyButton>().SetCountryName(countryInfo.countryName);
            loaded.transform.SetParent(scrollViewContent.transform, false);
        }
        return;
    }
    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
    }

    public void LoadViewProfileScreen()
    {
        UI_Manager.instance.playerInfos.Add(signupScript.playerInfo);
        try
        {
            Directory.CreateDirectory("Assets/Resources/Users/" + signupScript.playerInfo.name);
            Directory.CreateDirectory("Assets/Resources/Users/" + signupScript.playerInfo.name + "/Images");
            Directory.CreateDirectory("Assets/Resources/Users/" + signupScript.playerInfo.name + "/Items");
            Directory.CreateDirectory("Assets/Resources/Users/" + signupScript.playerInfo.name + "/Avatars");
            signupScript.playerInfo.itemsFolder = "Users/" + signupScript.playerInfo.name + "/Items";
            signupScript.playerInfo.imageFolder = "Users/" + signupScript.playerInfo.name + "/Images";
            signupScript.playerInfo.avatarFolder = "Users/" + signupScript.playerInfo.name + "/Avatars";
        }
        catch (IOException ex)
        {
            UI_Manager.instance.MakePopup(ex.Message);
        }
        UI_Manager.instance.UpdateJson();
        UI_Manager.instance.currentUser = UI_Manager.instance.playerInfos.Count-1;
        UI_Manager.instance.NextScreen(UI_Manager.Screen.O_ViewProfileScreen);
    }

    #endregion


    #endregion
}
