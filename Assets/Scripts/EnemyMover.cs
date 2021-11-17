using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;

    [SerializeField] float speed = 1f;
    [SerializeField] float offset_flash = 1f;
    [SerializeField] float offset_light = 1f;


    float EPS = 0.1f;
    private bool moveFromStartToEnd = true;
    private SpriteRenderer sr;
    private GameObject flashLight;
    private GameObject light;
    [SerializeField] float cl_offset;
    private Rigidbody rb;
    private BoxCollider cl;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        flashLight = transform.GetChild(0).gameObject;
        light = flashLight.transform.GetChild(0).gameObject;
        cl = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        if (moveFromStartToEnd)
        {
            if (sr.flipX)
            {
                sr.flipX = false;
                flashLight.transform.position += new Vector3(offset_flash, 0, 0);
                light.transform.position += new Vector3(offset_flash+ offset_light, 0, 0);
                flashLight.GetComponent<SpriteRenderer>().flipX = true;
                light.transform.Rotate(0, -180f, 0, Space.World);
                light.transform.position = new Vector3(light.transform.position.x, light.transform.position.y, -1);
                cl.center += new Vector3(cl_offset, 0, 0);
            }
            rb.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(endPoint.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime));
        }
        else
        {  // move from end to start
            if (!sr.flipX)
            {
                flashLight.transform.position += new Vector3(-offset_flash,0,0);
                light.transform.position += new Vector3(-offset_flash- offset_light, 0, 0);
                flashLight.GetComponent<SpriteRenderer>().flipX = false;
                sr.flipX = true;
                light.transform.Rotate(0, 180f, 0, Space.World);
                light.transform.position = new Vector3(light.transform.position.x, light.transform.position.y, -1);
                cl.center += new Vector3(-cl_offset, 0, 0);

            }
            rb.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(startPoint.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime));
        }

        if (System.Math.Abs(transform.position.x - startPoint.position.x) < EPS)
        {
            moveFromStartToEnd = true;
        }
        else if (System.Math.Abs(transform.position.x - endPoint.position.x) < EPS)
        {
            moveFromStartToEnd = false;
        }
    }
}
