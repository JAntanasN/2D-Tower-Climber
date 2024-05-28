using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCollision : MonoBehaviour
{

    public TextMeshProUGUI scoreTxT;
    public TextMeshProUGUI CoinsTxT;
    public AudioClip coinSound;
    public AudioClip hitSound;
    private int score = 0;
    private int coins = 0;
    private AudioSource coinAudioSource;
    private AudioSource hitAudioSource;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            coinAudioSource = audioSources[0];
            hitAudioSource = audioSources[1];
        }
        else
        {
            Debug.LogError("Two AudioSource components are required.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            score += 1;
            scoreTxT.text = score.ToString();

            TowerSpawner spawner = FindObjectOfType<TowerSpawner>();
            if (spawner != null)
            {
                spawner.SpawnPrefab();
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            coins += 1;
            CoinsTxT.text = "You have: " + coins.ToString();
            Destroy(collision.gameObject);

            if (coinSound != null && coinAudioSource != null)
            {
                coinAudioSource.PlayOneShot(coinSound);
            }
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);

            if (hitSound != null && hitAudioSource != null)
            {
                hitAudioSource.PlayOneShot(hitSound);
            }
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void DeductCoins(int amount)
    {
        coins -= amount;
        CoinsTxT.text = "You have: " + coins.ToString();
    }
}
