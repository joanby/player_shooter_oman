using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{

    public float delay = 5f;
    void Start()
    {
        //we destroy the object after delay seconds
        Destroy(gameObject, delay); 
    }
}
