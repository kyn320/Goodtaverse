using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIAchievePopup : UIBasePopup
{
    public Image thumbnail;
    public TextMeshProUGUI descriptionText;

    public TextMeshProUGUI progressText;

    public List<AchieveData> achieveDataList;
    public UIAchieveListView achieveListView;

    public override void Init(UIData uiData)
    {
        achieveListView.Init(achieveDataList, SelectAchieve);
    }

    public void SelectAchieve(int index) {
        //Check is clear
        var achieve = achieveDataList[index];
        thumbnail.sprite = achieve.thumbnail;
        descriptionText.text = achieve.description;
    }

}
