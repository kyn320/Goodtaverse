using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAimPointer : MonoBehaviour
{
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateAim(Vector3 mousePoint)
    {
        mousePoint.z = 0;
        rectTransform.anchoredPosition = mousePoint;
    }

}
