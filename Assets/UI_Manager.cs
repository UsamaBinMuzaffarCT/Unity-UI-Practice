using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    #region variables

    #region public-variables
    
    public static UI_Manager instance { get; private set; }
    
    #endregion
    
    #region private-variables
    
    [SerializeField] private GameObject welcomScreenPrefab;
    [SerializeField] private GameObject wannaLoginScreenPrefab;
    [SerializeField] private Canvas canvas;
    
    #endregion
    
    #endregion

    #region datastructures

    private Stack<GameObject> backStack = new Stack<GameObject>();
    
    #endregion

    #region delegates
    
    private delegate void PustToStackDelegate(GameObject add);
    
    #endregion

    #region functions
  
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
       GameObject loadedScreen = Instantiate(welcomScreenPrefab);
       loadedScreen.transform.SetParent(canvas.transform, false);
       Invoke("GoToLogin", 3f);
    }
    private void GoToLogin()
    {
        GameObject loadedScreen = Instantiate(wannaLoginScreenPrefab);
        loadedScreen.transform.SetParent(canvas.transform, false);
    }

    #endregion
}
