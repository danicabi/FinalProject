using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandMeds : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> pillPrefabs;
    [SerializeField] Transform thisPosition;
    void Start()
    {
        spawnPiil();
    }

    void spawnPiil(){
        int random = Random.Range(0,pillPrefabs.Count);
        Instantiate(pillPrefabs[random], thisPosition.position, Quaternion.identity);
    }
}
