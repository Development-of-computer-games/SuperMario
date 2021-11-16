using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onEagleCollision : MonoBehaviour
{
    private float setExplosion = 100;
    [SerializeField] GameObject prefabToSpawn;
    //the number of coins we want to recieve after hitting the eagle
    [SerializeField] int numOfCoinsDropped = 20;
    private float offset = 9f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
            // variable to set the animation of the frog to be explode
        // if the type of the collider we r on s edge collider, it means we r on the head of the frog.
        if (collision.gameObject.tag == "Laser")
        {
          this.gameObject.GetComponent<Animator>().SetFloat("Explosion", setExplosion);
            StartCoroutine(frogExplode());
        }
        // the frog ate us.
        else if (collision.gameObject.tag == "Player")
        {
            LoadSceneMode();
        }

    }
    private void dropCoins()
    {
        float minOffSet = 0.2f;
        for (int i = 0; i <= numOfCoinsDropped; i++)
        {
            Vector3 positionOfSpawnedObject = new Vector3(
          transform.position.x+ minOffSet,
          transform.position.y,
          transform.position.z);
            // instantiate a mashroom
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            minOffSet += minOffSet;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadSceneMode()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    private IEnumerator frogExplode()
{
        dropCoins();
    yield return new WaitForSeconds(1);
      
    Destroy(this.gameObject);
}
}
