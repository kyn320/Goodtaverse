using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AmountRangeInt
{
    public int min;
    public int max;

    public AmountRangeInt(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public int GetRandomAmount()
    {
        return Random.Range(min, max);
    }
}

[System.Serializable]
public class AmountRangeFloat
{
    public float min;
    public float max;

    public AmountRangeFloat(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float GetRandomAmount() { 
       return Random.Range(min, max); 
    }
}

[System.Serializable]
public class AmountRangeVector2
{
    public Vector2 min;
    public Vector2 max;

    public AmountRangeVector2(Vector2 min, Vector2 max)
    {
        this.min = min;
        this.max = max;
    }

    public Vector2 GetRandomAmount()
    {
        var random = Vector2.zero;
        random.x = Random.Range(min.x, max.x);  
        random.y = Random.Range(min.y, max.y);  

        return random;
    }
}

[System.Serializable]
public class AmountRangeVector3
{
    public Vector3 min;
    public Vector3 max;

    public AmountRangeVector3(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }
    public Vector3 GetRandomAmount()
    {
        var random = Vector3.zero;
        random.x = Random.Range(min.x, max.x);
        random.y = Random.Range(min.y, max.y);
        random.z = Random.Range(min.z, max.z);

        return random;
    }
}
