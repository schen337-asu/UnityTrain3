using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Spawn obstacles in the game at random intervals
*/
public class SpawnManager : MonoBehaviour
{

    private PlayerController playerControllerScript;
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, Random.Range(1f, 2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.getGameState() == false) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
