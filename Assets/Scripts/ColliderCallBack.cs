using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCallBack : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        GameObject collidedObject = other.gameObject;
        GarbageType garbageTypeObject = collidedObject.GetComponent<GarbageType>();
        GarbageType trashTypeGarbage = GetComponent<GarbageType>();

        if (trashTypeGarbage.garbageType == garbageTypeObject.garbageType)
        {
            Debug.Log("VOCE VENCEU MALDITO!!!!");
        }
        else
        {
            Debug.LogWarning("VOCE PERDEU INSETO");
        }

        Destroy(collidedObject);
    }

}
