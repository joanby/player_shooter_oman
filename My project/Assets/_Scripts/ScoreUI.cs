using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        scoreText.text = $"Score: {ScoreManager.sharedInstance.amount}";
    }
}
