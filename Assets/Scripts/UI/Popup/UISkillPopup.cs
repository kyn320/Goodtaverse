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
        //TODO :: ���� ���� ���Ⱑ �켱 ǥ�õǵ��� ����
        SelectCategory(0);
    }

    public void SelectCategory(int index)
    {
        //TODO :: ��ų ����Ʈ Ž��
        if (index < weaponCategory.Count)
        {
            currentSkillDataList = skillContainer.GetSkillList(weaponCategory[index], SkillCastType.None);
        }
        else
        {
            //�нú� Ž��
            currentSkillDataList = skillContainer.GetSkillList(WeaponType.None, SkillCastType.Passive);
        }

        pageListView.UpdateList(currentSkillDataList, SelectListSlot);
    }

    public void SelectListSlot(int index) {
        descriptionPage.SetData(currentSkillDataList[index]);
    }


}
