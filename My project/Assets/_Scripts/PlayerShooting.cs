using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    //Reference prefab
    [SerializeField]  private GameObject bullet;
    //Track shooting point
    [SerializeField] private Transform shootingPoint;
    //Time between bullets
    [SerializeField] private float fireRate;
    //Remaining bullets for the player
    [SerializeField] private float bulletsAmount;


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnFire(InputValue value)
    {

        //We play the shooting animation as soon as we press the button to fire
        animator.SetBool("Shooting", value.isPressed);

        if (value.isPressed)
        {
            //Wait fireRate for the first bullet and fireRate between bullets
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        else
        {
            CancelInvoke();
        }
            
    }

    //Method to shoot a bullet
    void Shoot()
    {
        //If the player has bullets and the game is not paused
        if (bulletsAmount > 0 && Time.timeScale > 0)
        {
            bulletsAmount--;//fire a new bullet


            Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);

            //TODO: show particle systems from the weapon
            //TODO: play sound from the weapon
        }
    }

}
