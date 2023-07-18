using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounrtyButton : MonoBehaviour
{
    #region variables

    [SerializeField] private TMP_Text countryName;
    [SerializeField] private TMP_Text countryCode;
    private GameObject parentScreen;

    #endregion

    #region functions

    public void SetCountryName(string countryName)
    {
        this.countryName.text = countryName;
    }

    public void SetCountryCode(string countryCode)
    {
        this.countryCode.text = countryCode;
    }

    #endregion
}
