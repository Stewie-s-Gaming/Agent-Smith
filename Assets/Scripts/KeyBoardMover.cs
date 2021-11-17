using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMover : MonoBehaviour
{
    [Tooltip("The horizontal force that the player's feet use for walking, in newtons.")]
    [SerializeField] float walkForce = 1000f;
    private ForceMode walkForceMode = ForceMode.Force;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(horizontal * walkForce, 0, 0), walkForceMode);
        rb.AddForce(new Vector3(0, vertical * walkForce, 0), walkForceMode);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        /*        transform.position += new Vector3(horizontal*walkForce*Time.deltaTime,vertical*walkForce * Time.deltaTime, 0);
        */
    }
}

