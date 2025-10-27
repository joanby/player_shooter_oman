using System;
using UnityEngine;
using UnityEngine.AI;

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

    private NavMeshAgent agent;

    private Animator animator;

    private void Awake()
    {
        //The component is not on the AI, but in the parent
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        baseTransform = GameObject.Find("PlayerBase").transform;
        GoToBase();
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
        //Stop shooting because we're running towards the base
        animator.SetBool("Shooting", false);

        //Instruct the AI to go to the player's base
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        LookTo(baseTransform.position);

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
        //When we reach the base, the AI doens't need to move anymore
        agent.isStopped = true;
        //Look at the base before firing
        LookTo(baseTransform.position);
        //make it fire to the base
        Shoot();
    }

    void ChasePlayer()
    {

        //Stop shooting because we're chasing the player
        animator.SetBool("Shooting", false);
        //The enemy needs to move towards the player
        agent.isStopped = false;

        //I lose the sight of the player
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        //Once I know I have the player in sight
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        LookTo(sightSensor.detectedObject.transform.position);

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

        //To attack the player, we stop the enemy from moving
        agent.isStopped = true;
        

        //If the player 'disappears' (or dies)
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        //After the IF; to ensure that sightsenor is NOT null
        //I want the enemy to look to the player
        LookTo(sightSensor.detectedObject.transform.position);
        // attack the player
        Shoot();

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

    public float lastShootTime; //To know how much time has it lapsed since the last shot
    public GameObject bulletPrefab; //This is the prefab we're going to fire
    public float fireRate; //How much time between two bullets being fired

    /// <summary>
    /// This method will shoot a bullet after the time has been lapsed.
    /// </summary>
    void Shoot()
    {
        animator.SetBool("Shooting", true);

        float timeSinceLastShot = Time.time - lastShootTime; //How much time since last shot
        if(timeSinceLastShot > fireRate) //If I have waited enough
        {
            lastShootTime = Time.time; //I record that now I'm going to fire a bullet
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        }
    }

    
    /// <summary>
    /// Rotates the player to look at the target position
    /// </summary>
    /// <param name="targetPosition"></param>
    void LookTo(Vector3 targetPosition)
    {

        //Calculate the direction from the enemy to the target
        Vector3 directionToPosition =
            Vector3.Normalize(targetPosition - this.transform.parent.position);
        directionToPosition.y = 0; //I don't want the enemy to go up or down
        //Change the forward direction of the parent to look towards the target
        this.transform.parent.forward = directionToPosition;
    }

}
