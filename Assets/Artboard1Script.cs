using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artboard1Script : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject artBoard2Prefab;
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

    public void LoadArtBoard2Screen()
    {
        manager.NextScreen(artBoard2Prefab);
    }

    #endregion

    #endregion
}
