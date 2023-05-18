using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dontdestroyonload : MonoBehaviour
{
    void Start()
    {
        List<GameObject> objects = new List<GameObject>(Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == gameObject.name));
        if (objects.Count > 1)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}