using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISkillPageSlot : MonoBehaviour
{
    private int index;

    [SerializeField]
    protected UIBaseImage iconImage;
    [SerializeField]
    protected UIBaseText nameText;

    private UnityAction<int> selectAction;

    public void SetData(int index,SkillData skillData) {
        this.index = index;
        iconImage.SetImage(skillData.icon);
        nameText.SetText(skillData.skillName);
    }

    public void SetEvent(UnityAction<int> selectAction) {
        this.selectAction = selectAction;
    }

    public void SelectSlot()
    {
        selectAction?.Invoke(index);
    }

}
