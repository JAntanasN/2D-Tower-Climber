using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChanger : MonoBehaviour
{
    public GameObject[] backgrounds; // My background images
    private int currentBackgroundIndex = 0;

    void Start()
    {
        if (backgrounds.Length > 0)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].SetActive(i == 0);
            }

            InvokeRepeating("ToggleBackground", 0f, 10f); // Change background every 10 seconds
        }
    }

    void ToggleBackground()
    {
        backgrounds[currentBackgroundIndex].SetActive(false);

        currentBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Length;

        backgrounds[currentBackgroundIndex].SetActive(true);
    }
}
