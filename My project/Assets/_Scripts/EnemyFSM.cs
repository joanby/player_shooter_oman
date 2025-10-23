using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        GoToBase, //enemy tries to go to the base of the player
        AttackBase, //enemy attacks the base when it gets close enough
        ChasePlayer, //enemy chases the player when it gets in the line of sight
        AttackPlayer //enemy attacks the player if it gets close enough
    }

    [Tooltip("Current state where the Enemy is right now")]
    public EnemyState currentState;

    public Sight sightSensor;

    [Tooltip("The position of the player base to attack")]
    private Transform baseTransform;
    [Tooltip("Minimum distance so the enemy can attack the base")]
    public float baseAttackDistance;
    [Tooltip("Minimum distance to attack the player")]
    public float playerAttackDistance;

    private void Start()
    {
        baseTransform = GameObject.Find("PlayerBase").transform;
    }

    //Logic of a FSM is always in the Update
    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.GoToBase:
                GoToBase();
                break;
            case EnemyState.AttackBase:
                AttackBase();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
        }
    }

    void GoToBase()
    {
        //If the player is in the line of sight, let's chase him
        if(sightSensor.detectedObject!= null)
        {
            currentState = EnemyState.ChasePlayer;
            return;
        }

        //Calculate how far the enemy is from the player base
        float distanceToTheBase = Vector3.Distance(this.transform.position, baseTransform.position);
        //If the enemy is close enough, let's attack the player base
        if(distanceToTheBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
            return;
        }
    }

    void AttackBase()
    {
        print("Attacking Base");
    }

    void ChasePlayer()
    {
        //I lose the sight of the player
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }


        //I get close enough to the player
        float distanceToPlayer = Vector3.Distance(this.transform.position,
            sightSensor.detectedObject.transform.position);
        if(distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
            return;
        }

    }

    void AttackPlayer()
    {
        //If the player 'disappears' (or dies)
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        //If the player goes far from the enemy, let's chase him
        float distanceToPlayer = Vector3.Distance(this.transform.position,
            sightSensor.detectedObject.transform.position);
        if(distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, baseAttackDistance);
    }


}
