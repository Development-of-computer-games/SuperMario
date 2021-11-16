using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script that when falling from high place, player fades for few seconds and his speed is lowering.
public class onCollisionFade : MonoBehaviour
{
    [SerializeField] float minImpulseForExplosion = 15.0f;
    [Tooltip("The duration the player gets slow motion when hiting object from high postion")] [SerializeField] float weakenDuration = 6f;
    [Tooltip("The player's force walking decreasion")] [SerializeField] float weakenDelay = 2.5f;
    /*    [SerializeField] GameObject explosionEffect = null;
        [SerializeField] float explosionEffectTime = 0.68f;*/

    // variable to know when to fade the player
    private bool isFaded = false;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // basically when hitiing the floor \ tubes \ bricks 
        if (collision.gameObject.tag != "Frog" || collision.gameObject.tag != "Eagle" || collision.gameObject.tag != "GoodMashroom")
        {
            // In 3D, the Collision object contains an .impulse field.
            // In 2D, the Collision2D object does not contain it - so we have to compute it.
            // Impulse = F * DeltaT = m * a * DeltaT = m * DeltaV
            float impulse = collision.relativeVelocity.magnitude * rb.mass;
            Debug.Log(gameObject.name + " collides with " + collision.collider.name
                + " at velocity " + collision.relativeVelocity + " [m/s], impulse " + impulse + " [kg*m/s]");
            if (impulse > minImpulseForExplosion && !isFaded) // to not fade the player multiple times
            {
                isFaded = true;
                StartCoroutine(weakenThePlayer());
            }
        }
    }

    private IEnumerator weakenThePlayer()
    {
        LeanTween.alpha(this.gameObject, 0.5f, weakenDuration).setEase(LeanTweenType.linear);
        // lowering walk speed because there was a collision
        this.GetComponent<KeyboardForceAdder>().walkForce -= weakenDelay;
        for (float i = weakenDuration; i > 0; i--)
        {


            yield return new WaitForSeconds(1);
        }
        // returning walk speed because time is up
        this.GetComponent<KeyboardForceAdder>().walkForce += weakenDelay;
        LeanTween.alpha(this.gameObject, 1f, 0.5f).setEase(LeanTweenType.linear);
        isFaded = false;
    }



}