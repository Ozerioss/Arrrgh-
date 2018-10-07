﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;
    public int amountOfTiles = 7;


    private Transform playerTransform;
    private float spawnZ = 10.0f;
    private float tileLength = 10f;
    private int lastPrefabIndex = 0;

	// Use this for initialization
	void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amountOfTiles; i++)
        {
            SpawnTile(0);
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Logic to spawn tiles as player goes
		if(playerTransform.position.z > (spawnZ - amountOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    void SpawnTile(int indexPrefab = -1)
    {
        GameObject go;
        int newIndex = RandomPrefabIndex(); // get random index

        go = Instantiate(tilePrefabs[newIndex]) as GameObject; //Instantiate random tile from list        

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }


    void DeleteTile()
    {
        //Logic to delete old tiles
    }


    // Custom random number generator
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
