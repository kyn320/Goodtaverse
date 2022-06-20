using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillPopup : UIBasePopup
{
    public SkillContainer skillContainer;
    public List<WeaponType> weaponCategory;

    public UISkillPageListView pageListView;
    public UISkillDescription descriptionPage;

    private List<SkillData> currentSkillDataList = new List<SkillData>();

    public override void Init(UIData uiData)
    {

    }

    public override void Open()
    {
        base.Open();
        //TODO :: 착용 중인 무기가 우선 표시되도록 세팅
        SelectCategory(0);
    }

    public void SelectCategory(int index)
    {
        //TODO :: 스킬 리스트 탐색
        if (index < weaponCategory.Count)
        {
            currentSkillDataList = skillContainer.GetSkillList(weaponCategory[index], SkillCastType.None);
        }
        else
        {
            //패시브 탐색
            currentSkillDataList = skillContainer.GetSkillList(WeaponType.None, SkillCastType.Passive);
        }

        pageListView.UpdateList(currentSkillDataList, SelectListSlot);
    }

    public void SelectListSlot(int index) {
        descriptionPage.SetData(currentSkillDataList[index]);
    }


}
