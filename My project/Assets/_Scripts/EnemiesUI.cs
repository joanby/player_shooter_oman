using TMPro;
using UnityEngine;

public class EnemiesUI : MonoBehaviour
{
    TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        scoreText.text = $"Remaining Enemies: {EnemiesManager.sharedInstance.enemies.Count}";
    }
}
