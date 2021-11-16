using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAround : MonoBehaviour
{
    //speed of rotation
    public float speed = 100;
    // direction of where the object should spin
    public Vector3 direction = Vector3.up; // (0,1,0)
    // Update is called once per frame
    void Update()
    {
        // we want to rotate the object, we give the position, the direction and speed
        transform.RotateAround(transform.position, direction, speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
