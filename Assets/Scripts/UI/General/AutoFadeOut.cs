using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFadeOut : MonoBehaviour
{
    private void Start()
    {
        FadeController.Instance.FadeOut();
    }
}
