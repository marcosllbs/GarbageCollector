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
    [SerializeField] TMP_Text garbageTypeText;
    GarbageType garbageType;

    public int points;
    public int hitStreak;
    public bool increaseVelocity = false;


    public float timeInterval = 5f;
    public float countDown = 0f;
    public float timeToChangeTrashBin = 10f;
    public float timeToChangeTrashBinCountDown = 0f;

    void Update()
    {

        countDown += Time.deltaTime;
        timeToChangeTrashBinCountDown += Time.deltaTime;

        if (hitStreak >= 1 && increaseVelocity)
        {
            timeInterval = System.Math.Max(1, timeInterval - 0.3f);
            increaseVelocity = false;
        }

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
        hitStreak++;

        if (hitStreak >= 1)
            increaseVelocity = true;

        pointsText.SetText($"Points:{points}");
    }

    public void CallFalseHitPoints()
    {
        points--;
        hitStreak = 0;
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
        garbageTypeText.SetText(trashBinGarbageTypeRealtime.garbageType.ToString());
        Debug.Log($"THE NEW TRASHBIN TYPE IS {trashBinGarbageTypeRealtime.garbageType}");
    }

    public void SetTrashBinColor()
    {
        Renderer trashbinRenderer = trashBinGameObject.GetComponent<Renderer>();
        switch (garbageType.garbageType)
        {
            case GarbageType.GarbageTypes.Plastic:
                trashbinRenderer.material.color = trashBinCollors[1];
                break;

            case GarbageType.GarbageTypes.Glass:
                trashbinRenderer.material.color = trashBinCollors[2];
                break;

            case GarbageType.GarbageTypes.Metal:
                trashbinRenderer.material.color = trashBinCollors[3];
                break;
        }
    }
}
