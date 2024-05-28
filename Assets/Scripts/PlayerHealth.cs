using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public float startingHealth = 3;
    public float currentHealth;
    public float maxHealth = 3;

    [Header("Hearts")]
    public GameObject Image1Alive;
    public GameObject Image2Alive;
    public GameObject Image3Alive;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine colorCoroutine;

    private PlayerCollision playerCollision;

    private void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthUI();

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        playerCollision = GetComponent<PlayerCollision>();
    }

    public void AddHeart()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHealthUI();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            currentHealth -= 1;
            UpdateHealthUI();

            Destroy(collision.gameObject);

            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            if (colorCoroutine != null)
            {
                StopCoroutine(colorCoroutine);
            }
            colorCoroutine = StartCoroutine(FlashRed());
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }

    private void UpdateHealthUI()
    {
        if (currentHealth == 3)
        {
            if (Image1Alive != null) Image1Alive.SetActive(true);
            if (Image2Alive != null) Image2Alive.SetActive(true);
            if (Image3Alive != null) Image3Alive.SetActive(true);
        }
        else if (currentHealth == 2)
        {
            if (Image1Alive != null) Image1Alive.SetActive(false);
            if (Image2Alive != null) Image2Alive.SetActive(true);
            if (Image3Alive != null) Image3Alive.SetActive(true);
        }
        else if (currentHealth == 1)
        {
            if (Image1Alive != null) Image1Alive.SetActive(false);
            if (Image2Alive != null) Image2Alive.SetActive(false);
            if (Image3Alive != null) Image3Alive.SetActive(true);
        }
        else
        {
            if (Image1Alive != null) Image1Alive.SetActive(false);
            if (Image2Alive != null) Image2Alive.SetActive(false);
            if (Image3Alive != null) Image3Alive.SetActive(false);
            CheckHealthAndRestart();
        }
    }

    private void CheckHealthAndRestart()
    {
        if (currentHealth <= 0)
        {
            if (playerCollision != null)
            {
                PlayerPrefs.SetInt("PlayerScore", playerCollision.GetScore());
            }
            SceneManager.LoadScene("EndScene");
        }
    }
}
