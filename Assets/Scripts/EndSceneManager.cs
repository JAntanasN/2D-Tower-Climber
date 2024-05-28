using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "You climbed " + playerScore.ToString() + " kilometers";
    }
}
