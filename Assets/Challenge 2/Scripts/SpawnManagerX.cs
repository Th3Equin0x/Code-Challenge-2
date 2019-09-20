/*
 * Stephen Gruver
 * SpawnManagerX.cs
 * Assignment 4
 * Spawns a random ball out of 3 possible prefabs in a random location on a random interval between 3s and 5s
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", (Random.Range(3.0f, 5.0f)));
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);

        //Nested Invoke()s achieve the same effect as an InvokeRepeating()
        float randomDelay = Random.Range(3.0f, 5.0f);
        Invoke("SpawnRandomBall", randomDelay);
    }

}
