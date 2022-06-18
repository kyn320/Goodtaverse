using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIKeySettingSlot : MonoBehaviour
{
    private KeyBind keyBind;

    [SerializeField]
    private TextMeshProUGUI keyNameText;
    [SerializeField]
    private Image keyIcon;
    [SerializeField]
    private TextMeshProUGUI testKeyCodeText;

    protected bool isKeyUpdate = false;

    public void SetData(KeyBind keyBind)
    {
        this.keyBind = keyBind;
        keyNameText.text = keyBind.name;
        //TODO :: KeyIcon Set
        testKeyCodeText.text = keyBind.keyCode.ToString();
    }

    public void ChangeKey()
    {
        isKeyUpdate = true;
    }

    private void Update()
    {
        if (isKeyUpdate && Input.anyKeyDown)
        {
            UpdateBindKey();
            isKeyUpdate = false;
        }
    }

    private void UpdateBindKey()
    {
        var updateKeyCode = KeyCode.None;

        IEnumerable<KeyCode> keyCodeList =
                Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();

        foreach (var currentKeyCode in keyCodeList)
        {
            if (Input.GetKeyDown(currentKeyCode))
            {
                updateKeyCode = currentKeyCode;
                break;
            }
        }

        keyBind.keyCode = updateKeyCode;
        testKeyCodeText.text = keyBind.keyCode.ToString();
    }

}
