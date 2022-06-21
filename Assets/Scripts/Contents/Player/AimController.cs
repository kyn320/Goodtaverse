using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AimController : MonoBehaviour
{
    public KeySettingData keySetting;

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

    private RaycastHit2D raycastHit;

    public void Update()
    {
        mouseScreenPoint = Input.mousePosition;
        updateScreenMousePointEvent?.Invoke(mouseScreenPoint);

        mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        updateWorldMousePointEvent?.Invoke(mouseWorldPoint);

        if (Input.GetKeyDown(keySetting.GetKeyBind(KeyType.Attack).keyCode))
        {
            //Attack KeyDown
            keyDownEvent?.Invoke(mouseWorldPoint);
            isHold = true;
        }

        if (Input.GetKeyUp(keySetting.GetKeyBind(KeyType.Attack).keyCode))
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
