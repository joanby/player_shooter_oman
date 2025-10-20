using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    [Tooltip("Amount of points that the user receives when the enemy dies")]
    public int amount;

    //Unity Event that is triggered automatically when the object gets destroyed
    private void OnDestroy()
    {
        ScoreManager.sharedInstance.amount += amount;
    }
}
