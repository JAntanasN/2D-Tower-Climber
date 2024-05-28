using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject store;
    public AudioClip buySound;

    private PlayerHealth playerHealth;
    private PlayerCollision playerCollision;
    private AudioSource audioSource;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerCollision = GameObject.FindWithTag("Player").GetComponent<PlayerCollision>();

        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleStoreVisibility()
    {
        bool isStoreActive = store.activeSelf;
        store.SetActive(!isStoreActive);

        if (isStoreActive)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void BuyHeart()
    {
        if (playerHealth != null && playerCollision != null)
        {
            int coins = playerCollision.GetCoins();
            if (coins >= 2 && playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerCollision.DeductCoins(2);
                playerHealth.AddHeart();

                if (buySound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(buySound);
                }
            }
        }
    }

    public void BuyPotion()
    {
        if (playerHealth != null && playerCollision != null)
        {
            int coins = playerCollision.GetCoins();
            if (coins >= 3)
            {
                playerCollision.DeductCoins(3);
                StartCoroutine(TemporarySpeedBoost());
            }
        }
    }

    IEnumerator TemporarySpeedBoost()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Player playerScript = player.GetComponent<Player>();
        float originalClimbSpeed = playerScript.climbSpeed;
        playerScript.climbSpeed = 10f;

        yield return new WaitForSeconds(15f);

        playerScript.climbSpeed = originalClimbSpeed;
    }
}
