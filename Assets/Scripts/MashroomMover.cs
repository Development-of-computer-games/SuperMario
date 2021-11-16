using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
 *  This component moves its object back and forth between two points in space, using a rigid body.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class MashroomMover : MonoBehaviour
{
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] Vector3 velocity;


    [Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;

    [SerializeField] float speed = 1f;

    private bool moveFromStartToEnd = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += velocity * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (moveFromStartToEnd)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime));
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
            rb.MovePosition(Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime));
        }
        if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(startPoint.position.x))
        {
            moveFromStartToEnd = true;
        }
        else if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(endPoint.position.x))
        {
            moveFromStartToEnd = false;
        }
    }

    public void SetVelocity(Vector3 newVelocity)
    {
        this.velocity = newVelocity;
    }
}
