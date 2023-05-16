using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResult : MonoBehaviour
{
    [SerializeField] private GameObject inv;

    private void OnMouseDown()
    {
        if (gameObject.activeInHierarchy)
        {
            Debug.Log("Object collected.");
            inv.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
