using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultilities 
{
    public static float CalculateAsymptoticAverage( float currentValue, float target, float percentage) {
        var result = 0.0f;
        result = (1 - percentage) * currentValue + percentage * target;
        return result;
    }

}
