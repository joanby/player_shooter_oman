
using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
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