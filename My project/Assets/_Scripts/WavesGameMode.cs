using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{

    [SerializeField] Life playerLife;

    // Update is called once per frame
    void Update()
    {
        //GAME WIN CONDITION
        //No more enemies and no more waves
        if(EnemiesManager.sharedInstance.enemies.Count <=0 &&
            WaveManager.sharedInstance.waves.Count <= 0)
        {
            SceneManager.LoadScene("You Win");
        }



        //GAME OVER CONDITION
        if(playerLife.amount <= 0)
        {
            SceneManager.LoadScene("You Lose");
        }
    }
}
