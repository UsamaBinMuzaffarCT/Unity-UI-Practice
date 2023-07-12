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
    [SerializeField] private GameObject loadingPrefab;
    [SerializeField] private Canvas canvas;
    private GameObject currentScreen;
    private GameObject mainScreen;

    #endregion
    
    #endregion

    #region datastructures

    private Stack<GameObject> backStack = new Stack<GameObject>();

    #endregion

    #region events

    #endregion

    #region delegates

    #endregion

    #region functions

    #region private-functions

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
       currentScreen = loadedScreen;
       Invoke("GoToLogin", 3f);
    }
    private void GoToLogin()
    {
        GameObject loadedScreen = Instantiate(wannaLoginScreenPrefab);
        loadedScreen.transform.SetParent(canvas.transform, false);
        currentScreen.SetActive(false);
        currentScreen = loadedScreen;
        mainScreen = loadedScreen;
    }

    private void PushToStack(GameObject stackScreen)
    {
        backStack.Push(stackScreen);
    }

    private GameObject PopFromStack()
    {
        GameObject screen = backStack.Pop();
        return screen;
    }

    private void ClearStack()
    {
        backStack.Clear();
    }

    private string CloneName(GameObject obj)
    {
        string name = obj.transform.name;
        string obj_name = "";
        for(int i = 0;i < name.Length-7;i++)
        {
            obj_name += name[i];
        }
        return obj_name;
    }

    private void CheckPrevious()
    {
        GameObject prevScreen = backStack.Pop();
        GameObject prevprevScreen = backStack.Pop();
        if( CloneName(prevScreen) == CloneName(backStack.Peek())) 
        {
            return;
        }
        else
        {
            PushToStack(prevprevScreen);
            PushToStack(prevScreen);
        }
    }

    #endregion

    #region public-functions

    public void MakeLoader()
    {
        GameObject loadingScreen = Instantiate(loadingPrefab);
        loadingScreen.transform.SetParent(canvas.transform, false);
    }

    public void Back()
    {
        currentScreen.SetActive(false);
        currentScreen = PopFromStack();
        currentScreen.SetActive(true);
        Debug.Log("Stack Size : " + backStack.Count.ToString());

    }

    public void NextScreen(GameObject nextScreen, bool clear=false, bool logout=false)
    {
        bool isPresent = false;
        if (clear)
        {
            ClearStack();
            if (!logout)
            {
                PushToStack(mainScreen);
            }
        }
        foreach (Transform child in canvas.transform)
        {
            if(child.transform.tag == "loading")
            {
                Destroy(child.gameObject);
            }
            if(CloneName(child.gameObject) == nextScreen.transform.name)
            {
                isPresent = true;
                currentScreen.SetActive(false);
                if (!clear)
                {
                    PushToStack(currentScreen);
                }
                child.gameObject.SetActive(true);
                currentScreen = child.gameObject;
                if(backStack.Count > 2)
                {
                    CheckPrevious();
                }
            }
        }
        if (!isPresent)
        {
            GameObject loadedScreen = Instantiate(nextScreen);
            loadedScreen.transform.SetParent(canvas.transform, false);
            currentScreen.SetActive(false);
            if (!clear)
            {
                PushToStack(currentScreen);
            }
            currentScreen = loadedScreen;
            if (backStack.Count > 2)
            {
                CheckPrevious();
            }
        }
        Debug.Log("Stack Size : " + backStack.Count.ToString());
    }
    
    #endregion
    
    #endregion

}
