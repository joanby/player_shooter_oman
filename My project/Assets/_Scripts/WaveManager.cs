
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



   
}