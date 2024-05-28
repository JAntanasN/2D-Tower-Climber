using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDownSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform[] squares;  // My 2 spawners
    public float shootInterval = 10f;  
    public float arrowSpeed = 10f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            timer = 0f;

            int randomIndex = Random.Range(0, squares.Length);
            Transform selectedSquare = squares[randomIndex];

            GameObject arrow = Instantiate(arrowPrefab, selectedSquare.position, Quaternion.identity);

            arrow.GetComponent<Rigidbody2D>().AddForce(Vector2.down * arrowSpeed, ForceMode2D.Impulse);

            Destroy(arrow, 5f);
        }
    }
}
