using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private HighlightItem leaf; 
    [SerializeField] private HighlightItem water;
    [SerializeField] private HighlightItem pbase;
    [SerializeField] private HighlightItem hair;
    [SerializeField] private HighlightItem claw;
    [SerializeField] private GameObject baseResult;
    [SerializeField] private GameObject finalPotion;

    void Update()
    {
        if (leaf.highlight.activeInHierarchy && water.highlight.activeInHierarchy && !(claw.highlight.activeInHierarchy || hair.highlight.activeInHierarchy))
        {
            leaf.highlight.SetActive(false); 
            water.highlight.SetActive(false);
            baseResult.SetActive(true);
        }
        if (pbase.highlight.activeInHierarchy && hair.highlight.activeInHierarchy && claw.highlight.activeInHierarchy)
        {
            finalPotion.SetActive(true);
        }
    }
}
