using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// question mark brick script

public class onPlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    private float offset = 9f;
    private bool isCreated = false ;
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      // when the player hits the question brick, we instantiate a good mashroom and destroy the brick
        if (!isCreated && collision.gameObject.tag=="Player")
        {
            Vector3 positionOfSpawnedObject = new Vector3(
                  transform.position.x,
                  transform.position.y + offset,
                  transform.position.z);
            // instantiate a mashroom
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            isCreated = true;
            Destroy(this.gameObject);
        
        }
      //  }
    }
    }
