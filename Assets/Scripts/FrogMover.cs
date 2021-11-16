using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMover : MonoBehaviour
{
    [Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;
    [SerializeField] Vector3 speed = new Vector3(-4f, 0f, 0f);
    [SerializeField]public Animator animator;
    private bool moveFromStartToEnd = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveFromStartToEnd)
        {
            animator.SetFloat("Horizontal", 1);
            transform.position -= speed * Time.deltaTime;
        }
        else
        {  // move from end to start
            animator.SetFloat("Horizontal", -1);
            transform.position += speed * Time.deltaTime;
        }
        if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(startPoint.position.x))
        {
            moveFromStartToEnd = true;
        }
        else if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(endPoint.position.x))
        {
            moveFromStartToEnd = false;
        }

        animator.SetFloat("Speed", speed.sqrMagnitude);
    }
}
