using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{

    private Rigidbody2D rigidbodyMainPlayer;

    private float walkingSpeed;
    private RaycastHit2D hitInfoDown;

    private void Start()
    {
        rigidbodyMainPlayer = GetComponent<Rigidbody2D>();
        walkingSpeed = 5F;
    }


    private void FixedUpdate()
    {
        Walk();
        Jump(); 
    }

    private void Walk()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 direction = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, walkingSpeed * Time.deltaTime);

        }
    }

    private void Jump()
    {
        hitInfoDown = Physics2D.Raycast(transform.position, Vector2.down, 0.6F);
        if (Input.GetKey(KeyCode.Space) && hitInfoDown.collider != null) rigidbodyMainPlayer.velocity = new Vector2(0, 1.5F);
    }

    
}
