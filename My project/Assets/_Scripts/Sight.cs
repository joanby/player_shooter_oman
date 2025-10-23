using UnityEngine;

public class Sight : MonoBehaviour
{
    [Tooltip("How far the enemy can see")]
    public float distance;
    [Tooltip("Spread of the vision of the enemy")]
    public float angle;

    public LayerMask objectsLayers;
    public LayerMask obstacleLayers;

    public Collider detectedObject;

    private void Update()
    {
        //Find all the objects inside of the sphere
        //of radius = distance centered in
        //the eyes of the player
        Collider[] colliders =
            Physics.OverlapSphere(this.transform.position, distance, objectsLayers);

        for(int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];

            //Vector that goes from the enemy towards the collider
            Vector3 dirToCollider = Vector3.Normalize(collider.bounds.center - this.transform.position);

            //To calculate the angle from the forward direction to the collider
            float angleToCollider = Vector3.Angle(transform.forward, dirToCollider);

            //Need to check if the angle is greater or smaller than angle of vision
            if(angleToCollider < angle)
            {
                //If there is NO obstacle between the enemy and the target
                if(!Physics.Linecast(this.transform.position, collider.bounds.center, out RaycastHit hit, obstacleLayers))
                {
                    //I can see the player
                    Debug.DrawLine(this.transform.position, collider.bounds.center, Color.green);
                    detectedObject = collider;
                    break;
                }
                else
                {
                    Debug.DrawLine(this.transform.position, hit.point, Color.red);
                }
            }

        }
    }

    //This is a unity even where we can draw our own gizmos
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, distance);


        Gizmos.color = Color.green;
        //To rotate a vector, we multiply a quaternion x a vector
        Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(this.transform.position, rightDirection * distance);

        Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(this.transform.position, leftDirection * distance);
    }

}
