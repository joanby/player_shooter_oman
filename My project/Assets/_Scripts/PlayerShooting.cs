using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    //Reference prefab
    [SerializeField]  private GameObject bullet;
    //Track shooting point
    [SerializeField] private Transform shootingPoint;

    public void OnFire(InputValue value)
    {
        if(value.isPressed)
            Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }

}
