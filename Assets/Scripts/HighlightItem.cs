using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    public GameObject highlight;

    void OnMouseDown()
    {

        if (highlight.activeInHierarchy && gameObject.activeInHierarchy)
        {
            highlight.SetActive(false);
        }
        else if (!highlight.activeInHierarchy && gameObject.activeInHierarchy)
        {
            highlight.SetActive(true);
        }
    }
}
