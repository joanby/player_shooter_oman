using UnityEngine;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager sharedInstance;

    public List<Enemy> enemies;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    } 
}
