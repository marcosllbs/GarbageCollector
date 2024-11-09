using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCallBack : MonoBehaviour
{

    [SerializeField] GameMecanics gameMecanics;

    private void OnCollisionEnter(Collision other)
    {
        GameObject collidedObject = other.gameObject;
        GarbageType garbageTypeObject = collidedObject.GetComponent<GarbageType>();
        GarbageType trashTypeGarbage = GetComponent<GarbageType>();

        if (trashTypeGarbage.garbageType == garbageTypeObject.garbageType)
        {
            Debug.Log("You Win");
            gameMecanics.CallHitPoints();
        }
        else
        {
            Debug.LogWarning("You Loose");
            gameMecanics.CallFalseHitPoints();
        }

        Destroy(collidedObject);
    }

}
