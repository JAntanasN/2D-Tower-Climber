using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public float shootInterval = 5f; 
    public float CoinSpeed = 10f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            timer = 0f;

            GameObject coin = Instantiate(CoinPrefab, transform.position, Quaternion.identity);

            coin.GetComponent<Rigidbody2D>().AddForce(Vector2.down * CoinSpeed, ForceMode2D.Impulse);

            Destroy(coin, 5f);
        }
    }
}
