using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject potion;

    public void ToggleStoreVisibility()
    {
        potion.SetActive(!potion.activeSelf);
    }
}
