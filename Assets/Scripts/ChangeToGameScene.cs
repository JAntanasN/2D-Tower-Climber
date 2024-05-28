using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToGameScene : MonoBehaviour
{
    public void SceneStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
