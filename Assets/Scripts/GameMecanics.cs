using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMecanics : MonoBehaviour
{
    [SerializeField] List<GameObject> placesToInstantiateObjects;
    [SerializeField] List<GameObject> objectsToInstantiate;

    public float timeInterval = 5f;
    public float countDown = 0f;

    void Update()
    {

        countDown += Time.deltaTime;
        if (countDown >= timeInterval)
        {
            Instantiate(objectsToInstantiate[RamdomizeObjectToInstantiate()], placesToInstantiateObjects[RamdomizePlaceToInstantiate()].transform);
            countDown = 0f;
        }

    }

    void Start()
    {

    }

    public int RamdomizePlaceToInstantiate()
    {
        int number;

        number = Random.Range(0, placesToInstantiateObjects.Count);

        return number;
    }

    public int RamdomizeObjectToInstantiate()
    {
        int number;

        number = Random.Range(0, objectsToInstantiate.Count);

        return number;
    }
}
