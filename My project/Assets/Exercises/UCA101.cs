using UnityEngine;

public class UCA101 : MonoBehaviour
{

    private int numberOfFrames;
    void Start()
    {
        Debug.Log("Hello");
    }

    void Update()
    {
        numberOfFrames++; 
        
        if (numberOfFrames <= 60)
        {
            Debug.Log("Frames:" + numberOfFrames);
        }
        
    }
}
