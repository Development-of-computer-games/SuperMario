using UnityEngine;

/**
 *  This component moves its object back and forth between two points in space, using a rigid body.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;

    [SerializeField] float speed = 10f;

    private bool moveFromStartToEnd = true;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (moveFromStartToEnd)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime));
        }
        else
        {  // move from end to start
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
}