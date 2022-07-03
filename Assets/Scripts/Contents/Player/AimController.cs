using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AimController : Singleton<AimController>
{
    private KeySettingData keySettingData;

    public UnityEvent<Vector3> updateScreenMousePointEvent;
    public UnityEvent<Vector3> updateWorldMousePointEvent;

    public UnityEvent<Vector3> keyDownEvent;
    public UnityEvent<Vector3> keyUpEvent;

    public bool isHold = false;
    public float currentHoldTime = 0f;
    public float startHoldTime = 0.2f;
    public UnityEvent<float> updateHoldTimeEvent;

    public Vector3 mouseScreenPoint;
    public Vector3 mouseWorldPoint;

    private void Start()
    {
        keySettingData = SettingManager.Instance.keySetting;
    }

    public void Update()
    {
        mouseScreenPoint = Input.mousePosition;
        updateScreenMousePointEvent?.Invoke(mouseScreenPoint);

        mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        updateWorldMousePointEvent?.Invoke(mouseWorldPoint);

        if (Input.GetKeyDown(keySettingData.GetKeyBind(KeyType.Attack).keyCode))
        {
            //Attack KeyDown
            keyDownEvent?.Invoke(mouseWorldPoint);
            isHold = true;
        }

        if (Input.GetKeyUp(keySettingData.GetKeyBind(KeyType.Attack).keyCode))
        {
            //Attack KeyUp   
            keyUpEvent?.Invoke(mouseWorldPoint);
            currentHoldTime = 0f;
            isHold = false;
        }

        if (isHold)
        {
            currentHoldTime += Time.deltaTime;
            if (startHoldTime >= currentHoldTime)
            {
                updateHoldTimeEvent?.Invoke(currentHoldTime);
            }
        }


    }

}
