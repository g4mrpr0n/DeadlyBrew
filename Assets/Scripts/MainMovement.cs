using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    public float moveSpeed = 3f;

    private GameObject Inventory;

    public Animator animator;
    // Update is called once per frame

    private void Start()
    {
        Inventory = GameObject.Find("Inventory").transform.Find("InventoryUI").gameObject;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < -1 || movement.x > 1 || movement.y > 1 || movement.y < -1)
        {
            Inventory.SetActive(false);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown("f") && Inventory.activeInHierarchy)
            Inventory.SetActive(false);
        else if (Input.GetKeyDown("f") && !Inventory.activeInHierarchy)
            Inventory.SetActive(true);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized* moveSpeed * Time.fixedDeltaTime);
    }
}
