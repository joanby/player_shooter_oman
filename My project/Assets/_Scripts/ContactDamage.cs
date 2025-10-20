using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [Tooltip("This is the amount of damage the bullet will make")]
    public float damage;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //This destroys the bullet

        //Get the life from the other collided game object
        Life life = other.GetComponent<Life>();
        //Safety check, in case the other doesn't have a life
        if(life != null)
        {
            life.amount -= damage;
           
        }
    }
}
