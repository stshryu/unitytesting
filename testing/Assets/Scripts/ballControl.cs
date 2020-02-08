using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    // Object Properties
    private float speed = 10f;
    private float jumpSpeed = 10f;
    private float distToGround = 0.5f;
    private int nonGroundedJumps = 3;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Debug.Log("Valid Jump");
            Vector3 jumpv = new Vector3(0, jumpSpeed, 0);
            rb.velocity = rb.velocity + jumpv;
        }

        float xmovement = Input.GetAxis("Horizontal");
        float zmovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xmovement * speed * Time.deltaTime, 0, zmovement * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);
    }

    // Check to see if object is touching ground
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + .2f);
    }
}
