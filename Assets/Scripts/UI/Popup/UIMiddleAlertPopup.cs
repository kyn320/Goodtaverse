using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMiddleAlertPopup : UIBasePopup
{
    [SerializeField]
    protected TextMeshProUGUI alertMessageText;

    private UIMiddleAlertPopupData alertData;

    public override void Init(UIData uiData)
    {
        alertData = uiData as UIMiddleAlertPopupData;

        alertMessageText.text = alertData.alertMessage;
    }

}
