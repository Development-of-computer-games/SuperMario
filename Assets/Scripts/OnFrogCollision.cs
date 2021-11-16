using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class OnFrogCollision : MonoBehaviour
{
    [SerializeField] float minImpulseForExplosion = 7.0f;
    /*    [SerializeField] GameObject explosionEffect = null;
        [SerializeField] float explosionEffectTime = 0.68f;*/

    // variable to set the animation of the frog to be explode
    private float setExplosion = 100;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if the type of the collider we r on s edge collider, it means we r on the head of the frog.
        if (collision.gameObject.tag == "Frog" && collision.collider.GetType()== typeof(EdgeCollider2D))
        {
            // In 3D, the Collision object contains an .impulse field.
            // In 2D, the Collision2D object does not contain it - so we have to compute it.
            // Impulse = F * DeltaT = m * a * DeltaT = m * DeltaV
            float impulse = collision.relativeVelocity.magnitude * rb.mass;
            Debug.Log(gameObject.name + " collides with " + collision.collider.name
                + " at velocity " + collision.relativeVelocity + " [m/s], impulse " + impulse + " [kg*m/s]");
            if (impulse > minImpulseForExplosion)
            {
                collision.gameObject.GetComponent<Animator>().SetFloat("isDead", setExplosion);
                StartCoroutine(frogExplode(collision.gameObject));
            }
            else
            {
                // we didnt hit the frog hard enough
                LoadSceneMode();

            }
        }
        // the frog ate us.
        else if(collision.gameObject.tag == "Frog")
        {
            LoadSceneMode();
        }
    }

    private void LoadSceneMode()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private IEnumerator frogExplode(GameObject frog)
    {
            yield return new WaitForSeconds(1);
        Destroy(frog);
    }
}
