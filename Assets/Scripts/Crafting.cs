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

    public CollectResult recipe;
    [SerializeField] private GameObject baseResult;
    [SerializeField] private GameObject finalPotion;

    void Update()
    {
        if (leaf.highlight.activeInHierarchy && water.highlight.activeInHierarchy && !(claw.highlight.activeInHierarchy || hair.highlight.activeInHierarchy) && !recipe.recipe1)
        {
            baseResult.SetActive(true);
        }
        else
        { 
            baseResult.SetActive(false); 
        }
        if (pbase.highlight.activeInHierarchy && hair.highlight.activeInHierarchy && claw.highlight.activeInHierarchy && !recipe.recipe2 && !(leaf.highlight.activeInHierarchy || water.highlight.activeInHierarchy))
        {
            finalPotion.SetActive(true);
        }
        else
        {
            finalPotion.SetActive(false);
        }
    }
}
