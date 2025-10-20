
using System;
using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
   

    public static WaveManager sharedInstance;

    public List<WaveSpawner> waves;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(sharedInstance);
        }
    }



    public GameObject prefab;
    public float startTime, spawnRate, endTime;


    private void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    private void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}