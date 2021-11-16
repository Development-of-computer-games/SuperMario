using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EagleMover : MonoBehaviour
{

    [SerializeField] Vector3 speed = new Vector3(-2f, 0f, 0f);
    [SerializeField]
    public Animator animator;

    void Start()
    {
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime;
        animator.SetFloat("Horizontal", 1);
        animator.SetFloat("Speed", speed.sqrMagnitude);
    }

}
