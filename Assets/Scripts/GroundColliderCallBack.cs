using UnityEngine;

public class GroundColliderCallBack : MonoBehaviour
{
    [SerializeField] GameMecanics gameMecanics;
    private void OnCollisionEnter(Collision other)
    {
        GameObject collidedObject = other.gameObject;
        gameMecanics.CallLostHits();
        Destroy(collidedObject);
    }
}