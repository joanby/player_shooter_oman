using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime, spawnRate, endTime;


    private void Start()
    {
        WaveManager.sharedInstance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    private void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    private void EndSpawner()
    {
        WaveManager.sharedInstance.RemoveWave(this);
        CancelInvoke();//To cancel the invoke
    }
}
