using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

public class GameMecanics : MonoBehaviour
{
    [SerializeField] List<GameObject> placesToInstantiateObjects;
    [SerializeField] List<GameObject> objectsToInstantiate;
    [SerializeField] List<Color> trashBinCollors;
    [SerializeField] GameObject trashBinGameObject;
    [SerializeField] TMP_Text pointsText;
    GarbageType garbageType;

    public int points;


    public float timeInterval = 5f;
    public float countDown = 0f;
    public float timeToChangeTrashBin = 10f;
    public float timeToChangeTrashBinCountDown = 0f;

    void Update()
    {

        countDown += Time.deltaTime;
        timeToChangeTrashBinCountDown += Time.deltaTime;
        if (countDown >= timeInterval)
        {
            Instantiate(objectsToInstantiate[RamdomizeObjectToInstantiate()], placesToInstantiateObjects[RamdomizePlaceToInstantiate()].transform);
            countDown = 0f;
        }
        if (timeToChangeTrashBinCountDown >= timeToChangeTrashBin)
        {
            RamdomizeTrashBin();
            timeToChangeTrashBinCountDown = 0f;
        }

    }

    void Start()
    {
        garbageType = trashBinGameObject.GetComponent<GarbageType>();
        RamdomizeTrashBin();
    }

    public int RamdomizePlaceToInstantiate()
    {
        int number;

        number = Random.Range(0, placesToInstantiateObjects.Count);

        return number;
    }

    public void CallHitPoints()
    {
        points++;
        pointsText.SetText($"Points:{points}");
    }

    public int RamdomizeObjectToInstantiate()
    {
        int number;

        number = Random.Range(0, objectsToInstantiate.Count);

        return number;
    }

    public void RamdomizeTrashBin()
    {
        GarbageType trashBinGarbageTypeRealtime = trashBinGameObject.GetComponent<GarbageType>();
        trashBinGarbageTypeRealtime.garbageType = garbageType.ReturnRandomGarbageType();
        SetTrashBinColor();
        Debug.Log($"THE NEW TRASHBIN TYPE IS {trashBinGarbageTypeRealtime.garbageType}");
    }

    public void SetTrashBinColor()
    {
        Renderer trashbinRenderer = trashBinGameObject.GetComponent<Renderer>();
        switch (garbageType.garbageType)
        {
            case GarbageType.GarbageTypes.Paper:
                trashbinRenderer.material.color = trashBinCollors[0];
                break;

            case GarbageType.GarbageTypes.Plastic:
                trashbinRenderer.material.color = trashBinCollors[1];
                break;

            case GarbageType.GarbageTypes.Glass:
                trashbinRenderer.material.color = trashBinCollors[2];
                break;

            case GarbageType.GarbageTypes.Metal:
                trashbinRenderer.material.color = trashBinCollors[3];
                break;

            case GarbageType.GarbageTypes.Organic:
                trashbinRenderer.material.color = trashBinCollors[4];
                break;

            case GarbageType.GarbageTypes.NonRecycle:
                trashbinRenderer.material.color = trashBinCollors[5];
                break;
        }
    }
}
