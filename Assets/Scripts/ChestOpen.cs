using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public SpriteRenderer sp;
    public Sprite newsprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stone"))
        {
            sp.sprite = newsprite;
        }
    }
}
