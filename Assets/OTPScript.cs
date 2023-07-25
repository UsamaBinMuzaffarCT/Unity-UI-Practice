using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OTPScript : MonoBehaviour
{
    #region variables
    
    [SerializeField] private List<TMP_InputField> inputFields;
    [SerializeField] private float time;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Button nextButton;
    private bool timeLeft = true;
    private int OTP;
    private List<char> OTPChars;
    private float timeValue;

    #endregion

    #region coroutines

    private IEnumerator InputOPT(List<TMP_InputField> inputFields)
    {
        int i = 0;
        while(i < 4)
        {
            inputFields[i].Select();
            while (inputFields[i].text.Length < 1)
            {
                yield return null;
            }
            i++;
        }
        nextButton.enabled = true;
    }

    private IEnumerator OTPTimer()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            float minutes = Mathf.FloorToInt((time + 1) / 60);
            float seconds = Mathf.FloorToInt((time + 1) % 60);
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            yield return null;
        }
        timeLeft = false;
    }

    #endregion

    #region functions

    #region private-functions

    private void Awake()
    {
        timeValue = time;
        nextButton.enabled = false;
        OTP = (int)Random.Range(1000f, 9999f);
        Debug.Log(OTP);
        OTPChars = OTP.ToString().ToCharArray().ToList<char>();
        StartCoroutine(InputOPT(inputFields));
        StartCoroutine(OTPTimer());
    }

    private bool CheckOTP()
    {
        for(int i = 0;i < OTPChars.Count; i++)
        {
            if (OTPChars[i] != inputFields[i].text.ToCharArray()[0])
            {
                return false;
            }
        }
        return true;
    }

    private void ClearOPT()
    {
        foreach(TMP_InputField field in inputFields)
        {
            field.text = string.Empty;
        }
    }

    #endregion

    #region public-functions

    public void Back()
    {
        UI_Manager.instance.Back();
        Destroy(gameObject);
    }

    public void GenerateNewOPT()
    {
        if (!timeLeft)
        {
            OTP = (int)Random.Range(1000f, 9999f);
            Debug.Log(OTP);
            OTPChars = OTP.ToString().ToCharArray().ToList<char>();
            timeLeft = true;
            time = timeValue;
            StartCoroutine(OTPTimer());
            ClearOPT();
            StartCoroutine(InputOPT(inputFields));
        }
    }

    public void LoadEnterNameScreen()
    {
        if (CheckOTP())
        {
            if (timeLeft)
            {
                UI_Manager.instance.NextScreen(UI_Manager.Screen.EnterNameScreen, add: false);
            }
            else
            {
                UI_Manager.instance.MakePopup("OTP Timed Out");
            }
        }
        else
        {
            UI_Manager.instance.MakePopup("Incorrect OTP");
        }
    }

    #endregion

    #endregion
}
