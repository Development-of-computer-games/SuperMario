using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player script -> when collision with mashroom
public class onGoodMashroomCollision : MonoBehaviour
{
    private float sizeTiming = 5f;
    private float jump = 8;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GoodMashroom")
        {
           
            this.gameObject.GetComponent<KeyboardForceAdder>().jumpImpulse += jump;
            // on collision with player, we destroy the mashroom and call the player function to size him up
            Destroy(collision.gameObject);
            startStizeUp();
        }
    }

    public void startStizeUp()
    {
        StartCoroutine(sizeUp());
    }
    public IEnumerator sizeUp()
    {
        Debug.Log("here");
        gameObject.transform.LeanScaleX(35f, 5f);
        gameObject.transform.LeanScaleY(35f, 5f);
        for (float i = sizeTiming; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }

        gameObject.transform.LeanScaleX(23f, 1f);
        gameObject.transform.LeanScaleY(26.5f, 1f);

        for (float i = sizeTiming; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
        this.gameObject.GetComponent<KeyboardForceAdder>().jumpImpulse -= jump;
    }
}
