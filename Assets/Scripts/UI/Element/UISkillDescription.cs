using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillDescription : MonoBehaviour
{
    [SerializeField]
    protected UIBaseText skillNameText;
    [SerializeField]
    protected UIBaseImage skillIcon;
    [SerializeField]
    protected UIBaseText weaponText;
    [SerializeField]
    protected UIBaseText actionTypeText;
    [SerializeField]
    protected UIAmountText coolTimeText;
    [SerializeField]
    protected UIAmountText spendMPText;
    [SerializeField]
    protected UIBaseText descriptionText;

    public void SetData(SkillData skillData)
    {
        skillNameText.SetText(skillData.skillName);
        skillIcon.SetImage(skillData.icon);

        StringBuilder allowWeaponDescription = new StringBuilder();
        var weaponCount = skillData.allowTypeList.Count;
        for(var i = 0 ; i < weaponCount; ++i) {
            //TODO :: 로컬라이즈 
            allowWeaponDescription.Append(skillData.allowTypeList[i].ToString());
            if(weaponCount > 1 && i < weaponCount - 1) {
                allowWeaponDescription.Append(",");
            }
        }
        weaponText.SetText(allowWeaponDescription.ToString());
        actionTypeText.SetText(skillData.castType.ToString());
        coolTimeText.UpdateAmount(skillData.originStatusInfo.GetElement(StatusType.CoolTime).GetAmount());
        spendMPText.UpdateAmount(skillData.subStatusInfo.GetElement(StatusType.MP).GetAmount());
        descriptionText.SetText(skillData.description);

    }
}
