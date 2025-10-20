using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);//This destroys the bullet
        Destroy(other.gameObject);//This destroys the other object
    }
}
