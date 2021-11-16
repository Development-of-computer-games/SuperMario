using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashroomCollision : MonoBehaviour
{
    Vector3 walkingLeft = new Vector3(-2f, 0, 0);
    Vector3 walkingRight = new Vector3(2f, 0, 0);
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LeftWall" || other.tag == "Block")
        {
            Debug.Log("LeftWall colision");
            GetComponent<MashroomMover>().SetVelocity(walkingRight);
        }
        else if (other.tag == "RightWall")
        {
            GetComponent<MashroomMover>().SetVelocity(walkingLeft);
        }
        else if (other.tag == "Player")
        {
            Debug.Log("Collision with player");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
