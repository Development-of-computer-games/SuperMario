using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for the user , movement and physics.

[RequireComponent(typeof (Rigidbody2D))] // this is crucial because who ever needs to use this class , needs to have rigidbody2d component.
public class KeyboardForceAdder : MonoBehaviour
{
    /*    [SerializeField] [Tooltip("The amount of force that the player has")] float forceSize = 10f;
        [SerializeField] [Tooltip("ForceMode of the system")] ForceMode2D forceMode = ForceMode2D.Force;
        [SerializeField] [Tooltip("The amount of torque that the player has")] float torqueSize = 10;
        [SerializeField] [Tooltip("Torque of the system")] ForceMode2D torqueMode = ForceMode2D.Force;*/
    [SerializeField] [Tooltip("The horizontal force that the player's feet use for walking , in newtons.")] public float walkForce = 16f;
    [SerializeField] [Tooltip("The vertical force that the player's feet use for jumping , in newtons.")] public float jumpImpulse = 8f;

    [Range(0,1f)]
    [SerializeField] float slowDownAtJump = 1f;
    private Rigidbody2D rb;
    private TouchDetector td;

    private ForceMode2D walkForceMode = ForceMode2D.Force;
    private ForceMode2D jumpForceMode = ForceMode2D.Impulse;
    private bool playerWantsToJump = false;
    // variable to help us do animation for the image player
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        td = GetComponent<TouchDetector>();
    }
    void Update()
    {
        // keyboard are tested each frame, so we should check them here
        if (Input.GetKeyDown(KeyCode.Space))
            playerWantsToJump = true;
    }
    /*
     * Note that updates related to the physics engine should be done in FixedUpdate and not in Update!
     */
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (td.IsTouching())
        {  // allow to walk and jump 
            rb.AddForce(new Vector3(horizontal * walkForce, 0, 0), walkForceMode);
            if (playerWantsToJump)
            {            // Since it is active only once per frame, and FixedUpdate may not run in that frame!
                rb.velocity = new Vector3(rb.velocity.x * slowDownAtJump, rb.velocity.y);
                rb.AddForce(new Vector3(0, jumpImpulse, 0), jumpForceMode);
                playerWantsToJump = false;
            }
        }
        else
        {
            rb.AddForce(new Vector3(horizontal, 0, 0), walkForceMode);
        }
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Speed", (new Vector3(rb.velocity.x * slowDownAtJump, rb.velocity.y)).sqrMagnitude);
    }
}
