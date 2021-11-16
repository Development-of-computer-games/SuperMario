using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script unUsed -> was for creating a mashrooms spawner
/// </summary>
public class SpawnAngryMashroom : MonoBehaviour
{
    [SerializeField] MashroomMover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")]
    [SerializeField]
    float minTimeBetweenSpawns = 4f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")]
    [SerializeField]
    float maxTimeBetweenSpawns = 8f;
    Vector3 speed = new Vector3(-2f, 0, 0);
       
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Debug.Log("creating");
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.GetComponent<MashroomMover>().SetVelocity(speed);
           // Debug.Log(positionOfSpawnedObject);
        }
    }
}
