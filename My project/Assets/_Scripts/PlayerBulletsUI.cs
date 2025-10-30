using TMPro;
using UnityEngine;

public class PlayerBulletsUI : MonoBehaviour
{

    TMP_Text bulletsText;

    public PlayerShooting player;

    private void Awake()
    {
        bulletsText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        bulletsText.text = $"Bullets : {player.GetBullets()}";
    }

}
