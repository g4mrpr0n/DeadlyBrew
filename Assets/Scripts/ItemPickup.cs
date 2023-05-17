using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private bool isActive = false;
    public GameObject obj;
    public string str= "HairUI";
    //public CollectResult rec;



    void Update()
    {
        if (Input.GetButtonDown("Submit") && isActive  /*!obj.activeInHierarchy && !rec.recipe1*/) // Check if not typing
        {
            GameObject.Find("Inventory").transform.Find("InventoryUI").Find(str).gameObject.SetActive(true);
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