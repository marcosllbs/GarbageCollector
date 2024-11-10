using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageType : MonoBehaviour
{
    public enum GarbageTypes
    {
        Plastic,
        Glass,
        Metal
    }
    public GarbageTypes garbageType;

    public GarbageTypes ReturnRandomGarbageType()
    {
        Array values = Enum.GetValues(typeof(GarbageTypes));
        System.Random random = new System.Random();
        int randomIndex = random.Next(values.Length);

        return (GarbageTypes)values.GetValue(randomIndex);
    }
}
