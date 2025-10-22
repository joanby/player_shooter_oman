
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
   

    public static WaveManager sharedInstance;

    public List<WaveSpawner> waves;
    public UnityEvent onChange;

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


    public void AddWave(WaveSpawner wave)
    {
        waves.Add(wave);
        onChange.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
        onChange.Invoke();
    }


   
}