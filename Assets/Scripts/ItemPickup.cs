using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private bool isActive = false;
    public GameObject leaf;
    public GameObject water;

    // Update is called once per
    // 

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && isActive && !leaf.activeInHierarchy) // Check if not typing
        {
            leaf.SetActive(true);
        }

        if (Input.GetButtonDown("Submit") && isActive && !water.activeInHierarchy) // Check if not typing
        {
            water.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = false;
        }
    }

}