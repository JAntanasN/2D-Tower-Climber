using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;

    public void SpawnPrefab()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
    }
}
