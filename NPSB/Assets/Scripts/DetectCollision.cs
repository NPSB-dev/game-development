using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameObject beer;
    public GameObject beerPrefab;
    public float coolDown = 3.0f;
    public float respawnTime = 5.0f;
    private float spawnTime;
    private bool isRendered = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "beer")
        {
            beer = other.gameObject;
            StartCoroutine(ShowAndHide(coolDown)); 
        }
    }

    void Start()
    {
        randomRespawn();
    }

    void Update()
    {
        if (Globals.freezeInteractions)
            return;

        if(Time.time - spawnTime > respawnTime && isRendered)
        {
            randomRespawn();
            spawnTime = Time.time;
        }
    }

    IEnumerator ShowAndHide(float coolDown)
    {
        Destroy(beer);
        isRendered = false;
        yield return new WaitForSeconds(coolDown);
        spawnTime = Time.time;
        randomRespawn();
        isRendered = true;
    }

    void randomRespawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
        beer = Instantiate(beerPrefab, randomSpawnPosition, Quaternion.identity);
        Destroy(beer, 5);
        isRendered = true;
    }



}








