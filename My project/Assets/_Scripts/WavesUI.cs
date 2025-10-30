using TMPro;
using UnityEngine;

public class WavesUI : MonoBehaviour
{
    TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        scoreText.text = $"Remaining Waves: {WaveManager.sharedInstance.waves.Count}";
    }
}
