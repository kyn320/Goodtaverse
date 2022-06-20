using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UISkillPageListView : UIListView<UISkillPageSlot>
{

    public void UpdateList(List<SkillData> skillDataList, UnityAction<int> selectAction)
    {
        RemoveAll();
        for(var i = 0 ; i < skillDataList.Count; ++i) { 
            var content = AddContent();
            content.SetData(i,skillDataList[i]);  
            content.SetEvent(selectAction);
        }
        ScrollVertical(0);
    }

}
