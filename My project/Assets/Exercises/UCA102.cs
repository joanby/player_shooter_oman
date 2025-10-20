using UnityEngine;

//Grid Movement on the XZ plane
public class UCA102 : MonoBehaviour
{
    public float step = 1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.position += Vector3.left * step; //-X
            //transform.Translate(Vector3.left * step);
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.position += Vector3.right * step; //+X
        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.position += Vector3.forward * step; //+Z
        if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.position += Vector3.back * step; //-Z
    }
}
