using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IcebergSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject IcebergPrefab;
    private float IcebergLength;
    
    [SerializeField]
    private float spawnHeight;
    
    [SerializeField]
    GameObject player;

    Vector2 IcebergSpawnPosition;
    Vector2 LastIcebergPosition;

    [SerializeField]
    private float icebergChance;

    private float icebergTimer;

    [SerializeField] private float baseTime;

    void Start()
    {
        IcebergLength = IcebergPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        
        IcebergSpawnPosition = new Vector2(player.transform.position.x+IcebergLength,spawnHeight); ;
        Instantiate(IcebergPrefab, IcebergSpawnPosition, Quaternion.identity);
        LastIcebergPosition = IcebergSpawnPosition;
        icebergTimer = 1;
    }


    private void Update()
    {

        if (player.transform.position.x > LastIcebergPosition.x){

            if (icebergTimer > 0)
            {
                icebergTimer -= Time.deltaTime;
            }
            else
            {
                if (Random.Range(0, 100) < icebergChance)
                {
                    IcebergSpawnPosition = new Vector2(player.transform.position.x+IcebergLength,spawnHeight) ;
                    Instantiate(IcebergPrefab, IcebergSpawnPosition, Quaternion.identity);
                    LastIcebergPosition = IcebergSpawnPosition;
                }

                icebergTimer = 1f;
            }
        }

        icebergChance =  (60-(TimeManager.instance.GetCurTime()/baseTime*6));

    }
}
