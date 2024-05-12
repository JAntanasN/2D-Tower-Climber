using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            TowerSpawner spawner = FindObjectOfType<TowerSpawner>();
            if (spawner != null)
            {
                spawner.SpawnPrefab();

                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
            }
        }
    }
}
