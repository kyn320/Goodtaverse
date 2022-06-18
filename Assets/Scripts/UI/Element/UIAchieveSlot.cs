using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UIAchieveSlot : MonoBehaviour
{
    protected int index;

    public TextMeshProUGUI descriptionText;

    [SerializeField]
    protected UnityEvent<int> selectEvent;

    public void SetData(int index, AchieveData achieveData)
    {
        this.index = index;
        descriptionText.text = string.Format("{0}.{1}", index + 1, achieveData.achieveName);
    }

    public void AddSelectEvent(UnityAction<int> selectAction) {
        selectEvent.AddListener(selectAction);
    }

    public void Open()
    {
        selectEvent?.Invoke(index);
    }

}
