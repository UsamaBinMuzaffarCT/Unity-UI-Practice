using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignupScript : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject phoneNumber;
    [SerializeField] private GameObject email;
    [SerializeField] private GameObject wallet;
    [SerializeField] private UI_Manager manager;
    #endregion

    #region functions
    #region private-functions

    private void Awake()
    {
        manager = GameObject.Find("UI Manager").GetComponent<UI_Manager>();
    }

    #endregion

    #region public-functions

    public void Back()
    {
        manager.Back();
    }

    public void LoadNumberScreen()
    {
        manager.NextScreen(phoneNumber);
    }
    public void LoadEmailScreen()
    {
        manager.NextScreen(email);
    }

    #endregion

    #endregion
}
