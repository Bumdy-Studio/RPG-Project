using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
    [SerializeField] private float boxSpawnRate = 1f;
    [SerializeField] private GameObject box;
    [SerializeField] private Vector3 startingVelocity;
    
    
    Queue<GameObject> boxesToDelete = new Queue<GameObject>();
    private float timeToSpawn = 0f;

    void Start() {
        timeToSpawn = boxSpawnRate + (Random.Range(0, 100) / 10);
        
        //Add some null values to create a delay between the box that was created and the box that is being deleted
        for (int i = 0; i < 7; i++) {
            boxesToDelete.Enqueue(null);
        }
    }
    
    void Update()
    {

        if (timeToSpawn > 0) {
            timeToSpawn -= Time.deltaTime;
            return;
        }

        timeToSpawn = boxSpawnRate;
        
        //Spawn box
        GameObject gm = Instantiate(box, transform.position, Quaternion.identity);
        gm.GetComponent<Rigidbody>().velocity = startingVelocity;
        boxesToDelete.Enqueue(gm);
        
        //Delete old box
        Destroy(boxesToDelete.Dequeue());
    }
}
