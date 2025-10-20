using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        EnemiesManager.sharedInstance.AddEnemy(this);
    }

    void OnDestroy()
    {
        EnemiesManager.sharedInstance.RemoveEnemy(this);
    }
}
