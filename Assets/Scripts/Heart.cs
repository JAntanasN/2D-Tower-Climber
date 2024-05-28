using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject heart;

    public void ToggleStoreVisibility()
    {
        heart.SetActive(!heart.activeSelf);
    }
}
