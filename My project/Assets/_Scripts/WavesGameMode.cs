using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{

    [SerializeField] Life playerLife;
    [SerializeField] Life playerBaseLife;

    private void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);

        EnemiesManager.sharedInstance.onChange.AddListener(CheckWinCondition);
        WaveManager.sharedInstance.onChange.AddListener(CheckWinCondition);
    }

    //GAME OVER CONDITION
    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("You Lose");
    }
    //GAME WIN CONDITION
    void CheckWinCondition()
    {
        //No more enemies and no more waves
        if (EnemiesManager.sharedInstance.enemies.Count <= 0 &&
            WaveManager.sharedInstance.waves.Count <= 0)
        {
            SceneManager.LoadScene("You Win");
        }
    }

   
}
