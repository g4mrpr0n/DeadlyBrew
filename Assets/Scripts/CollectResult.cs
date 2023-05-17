using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResult : MonoBehaviour
{
    [SerializeField] private GameObject inv;
    [SerializeField] private GameObject leaf;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject pbase;
    [SerializeField] private GameObject claw;
    [SerializeField] private GameObject hair;
    public int recipe;
    public bool recipe1 = false;
    public bool recipe2 = false;

    private void OnMouseDown()
    {
        if (gameObject.activeInHierarchy)
        {
            if (recipe == 0)
            {
                water.SetActive(false);
                leaf.SetActive(false);
                recipe1 = true;
            }
            else if (recipe == 1)
            {
                pbase.SetActive(false);
                claw.SetActive(false);
                hair.SetActive(false);
                recipe2 = true;
            }
            inv.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
