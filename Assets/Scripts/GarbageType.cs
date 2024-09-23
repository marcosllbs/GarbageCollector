using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageType : MonoBehaviour
{
    public enum GarbageTypes
    {
        Plastic,
        Metal,
        Organic,
        Paper,
        Glass,
        NonOrganic
    }
    public GarbageTypes garbageType;
}
