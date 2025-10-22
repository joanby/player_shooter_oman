using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{

    private float _amount;
    public UnityEvent onDeath;

    public float amount
    {
        set
        {
            _amount = value;
            if (_amount <= 0)
            {
                onDeath.Invoke();
                Destroy(gameObject);
            }
        }
        get
        {
            return _amount;
        }
    }

    [SerializeField]
    [Tooltip("This variable is to set the life on the inspector")]
    private float initialLife;

    private void Awake()
    {
        amount = initialLife;
    }



}
