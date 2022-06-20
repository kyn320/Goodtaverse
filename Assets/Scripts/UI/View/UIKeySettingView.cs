using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIKeySettingView : UIListView<UIKeySettingSlot>
{
    [SerializeField]
    protected KeySettingData keySetting;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        var keyDic = keySetting.keyBindDic;
        var keyList = keyDic.Keys.ToList();

        for (var i = 0; i < keyList.Count; ++i)
        {
            var content = AddContent();
            content.SetData(keyDic[keyList[i]]);
        }
    }

}
