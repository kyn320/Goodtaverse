using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class UIBattleGauge : MonoBehaviour
{
    [SerializeField]
    protected UIBaseGauge hpGauge;
    [SerializeField]
    protected UIBaseGauge mpGauge;
    [SerializeField]
    protected UIBaseGauge shieldGauge;

    [SerializeField]
    protected UICompareAmountText hpAmountText;
    [SerializeField]
    protected UICompareAmountText mpAmountText;

    public void Start()
    {
        
    }

    public void UpdateHP(float current, float max) {
        hpGauge.UpdateGauge(current,max);
        hpAmountText.UpdateAmount(current,max); 
    }

    public void UpdateMP(float current, float max)
    {
        mpGauge.UpdateGauge(current, max);
        mpAmountText.UpdateAmount(current, max);
    }

    public void UpdateShield(float current, float max)
    {
        shieldGauge.UpdateGauge(current, max);

    }

}
