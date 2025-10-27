using UnityEngine;

public class VelocityAnimator : MonoBehaviour
{

    Rigidbody rb;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", rb.linearVelocity.magnitude);
    }
}
