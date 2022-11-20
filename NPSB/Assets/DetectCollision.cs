using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject beer;
    public float coolDown = 3.0f;
    public float respawnTime = 5.0f;
    private float spawnTime;
    private bool isRendered = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Beer")
        {
            StartCoroutine(ShowAndHide(coolDown)); 
        }
    }

    void Update()
    {
        if(Time.time - spawnTime > respawnTime && isRendered == true)
        {
            randomRespawn();
            spawnTime = Time.time;
        }
    }

    IEnumerator ShowAndHide(float delay)
    {
        beer.transform.position = new Vector3(0, -1, 0);
        isRendered = false;
        yield return new WaitForSeconds(delay);
        spawnTime = Time.time;
        randomRespawn();
        isRendered = true;
    }

    void randomRespawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
        beer.transform.position = randomSpawnPosition;
    }
}








