using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float spawnHeightRange = 4f;
    public int numberOfArrows = 1;

    private float timer = 0f;
    private float squareHeight;
    private float shootInterval;

    void Start()
    {
        shootInterval = Random.Range(3f, 6f);
        squareHeight = transform.localScale.y;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            timer = 0f;

            for (int i = 0; i < numberOfArrows; i++)
            {
                float randomSpawnHeight = Random.Range(-squareHeight / 2f, squareHeight / 2f);
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomSpawnHeight, transform.position.z);

                GameObject arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);

                arrow.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10f, ForceMode2D.Impulse);

                Destroy(arrow, 5f);
            }

            shootInterval = Random.Range(3f, 6f);
        }
    }
}
