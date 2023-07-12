using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpetualRotationScript : MonoBehaviour
{
    #region variables
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float degreesPerSecond = -20;
    #endregion

    #region function

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.Rotate(new Vector3(0, 0, degreesPerSecond)* Time.deltaTime);
    }

    #endregion
}
