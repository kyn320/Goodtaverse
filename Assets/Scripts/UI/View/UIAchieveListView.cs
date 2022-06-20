using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAchieveListView : UIListView<UIAchieveSlot>
{

    public void Init(List<AchieveData> achieveDataList, UnityAction<int> selectAction)
    {
        for (var i = 0; i < achieveDataList.Count; ++i)
        {
            var content = AddContent();
            content.SetData(i, achieveDataList[i]);
            content.AddSelectEvent(selectAction);
        }
    }


}
