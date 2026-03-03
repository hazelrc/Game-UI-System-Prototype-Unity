using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private Spawnmanager spawnmanager;
    // Start is called before the first frame update
    void Start()
    {
        spawnmanager = GameObject.Find("SpawnManager").gameObject.GetComponent<Spawnmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Touched by: " + other.tag);
        if (other.CompareTag("good")) {
            Destroy(other.gameObject);
            spawnmanager.setLives(1);
        }
        Destroy(other.gameObject);
    }
}
