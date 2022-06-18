using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingPopup : UIBasePopup
{
    [SerializeField]
    private GameObject currentOpenPanel;
    public List<GameObject> categoryPanelList;

    public override void Init(UIData uiData)
    {

    }

    public void Open(int index)
    {
        currentOpenPanel?.SetActive(false);
        currentOpenPanel = categoryPanelList[index];
        currentOpenPanel.SetActive(true);
    }

}
