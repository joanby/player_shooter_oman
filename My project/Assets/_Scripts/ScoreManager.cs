using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager sharedInstance;

    //VARIABLES OF THE CLASS
    private int _amount;
    public int amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
            if(_amount < 0 )
            {
                _amount = 0;
            }
        }
    }

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this; //I am the shared instance
        }
        else
        {
            //We guarantee there is only one copy available
            Destroy(gameObject);
            Debug.LogError("Duplicated Score Manager, ignore (or destroy) this one ", gameObject);
        }
    }

}
