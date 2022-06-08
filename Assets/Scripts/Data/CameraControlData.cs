using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraControlData" , menuName = "Camera/CameraControl", order = 0)]
public class CameraControlData : ScriptableObject
{
    [SerializeField]
    private int rotateAxisCount = 8;

    public int GetAxisCount() { 
        return rotateAxisCount;
    }

    public float GetDegreePerAxis() { 
        return 360f / rotateAxisCount;
    }
}
