using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 5;
    private float ySpawnPos = -4;
    private Spawnmanager spawnmanager;
    public int pointValue;
    public ParticleSystem particle;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        particle.Stop();
        spawnmanager = GameObject.Find("SpawnManager").gameObject.GetComponent<Spawnmanager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        int noCollideLayer = LayerMask.NameToLayer("NoCollide");
        Physics.IgnoreLayerCollision(noCollideLayer, noCollideLayer, true);
    }

    Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    // Update is called once per frame
    void Update()
    {

    }

    //private void OnMouseDown() {
    //    if (spawnmanager.getGameOver() == false) {
    //        if (CompareTag("good")) {
    //            spawnmanager.setGoodIsPressed(true);
    //            Destroy(gameObject);
    //            spawnmanager.setScore(pointValue);
    //            Instantiate(particle, transform.position, particle.transform.rotation);
    //        } else if (CompareTag("bad")) {
    //            spawnmanager.setBadIsPressed(true);
    //            Destroy(gameObject);
    //            spawnmanager.setScore(pointValue);
    //            Instantiate(particle, transform.position, particle.transform.rotation);
    //            spawnmanager.setLives(1);              
    //        }
          
    //    }
    //}

    public void DestroyTarget() {
        if (spawnmanager.isGameActive) {
            if (CompareTag("good")) {
                spawnmanager.setGoodIsPressed(true);
                Destroy(gameObject);
                spawnmanager.setScore(pointValue);
                Instantiate(particle, transform.position, particle.transform.rotation);
            }
            else if (CompareTag("bad")) {
                spawnmanager.setBadIsPressed(true);
                Destroy(gameObject);
                spawnmanager.setScore(pointValue);
                Instantiate(particle, transform.position, particle.transform.rotation);
                spawnmanager.setLives(1);
            }
        }
    }


}
