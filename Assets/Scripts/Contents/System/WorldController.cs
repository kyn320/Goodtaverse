using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : Singleton<WorldController>
{
    public Light sunLight;

    private void Start()
    {
        DayNightSystem.Instance.SetSunLight(sunLight);
        DayNightSystem.Instance.UseUpdateTime(true);
    }

}
