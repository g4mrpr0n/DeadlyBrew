using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    public GameObject highlight;

    void OnMouseDown()
    {
        Debug.Log(gameObject.activeInHierarchy);
        Debug.Log(highlight.activeInHierarchy);
        if (highlight.activeInHierarchy && gameObject.activeInHierarchy)
        {
            Debug.Log("Hightlight inactive.");
            highlight.SetActive(false);
        }
        else if (!highlight.activeInHierarchy && gameObject.activeInHierarchy)
        {
            Debug.Log("Hightlight active.");
            highlight.SetActive(true);
        }
    }
}
