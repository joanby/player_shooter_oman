using UnityEngine;


[RequireComponent(typeof(Life))]
public class ScoreOnDeath : MonoBehaviour
{
    [Tooltip("Amount of points that the user receives when the enemy dies")]
    public int amount;

    private void Awake()
    {
        Life life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);
    }

    private void GivePoints()
    {
        ScoreManager.sharedInstance.amount += amount;
    }
}
