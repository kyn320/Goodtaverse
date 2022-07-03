using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDamageText : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;

    public void SetAmount(int damageAmount)
    {
        text.text = string.Format("{0}", damageAmount);
    }

}
