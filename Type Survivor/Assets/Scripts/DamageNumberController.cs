using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    private void Awake()
    {
        instance = this; 
    }

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;

    private List<DamageNumber> numberPool = new List<DamageNumber>();

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            SpawnDamage(57f, new Vector3(4, 3, 0));
        }
    }

    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);
        DamageNumber newDamage = GetFromPool();
        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);

        newDamage.transform.position = location;

    }

    public DamageNumber GetFromPool()
    {
        DamageNumber numberToOutPut = null;

        if(numberPool.Count == 0)
        {
            numberToOutPut = Instantiate(numberToSpawn, numberCanvas);
        } else
        {
            numberToOutPut = numberPool[0];
            numberPool.RemoveAt(0);
        }

        return numberToOutPut;
    }

    public void PlaceInPool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);
        numberPool.Add(numberToPlace);
    }
}
