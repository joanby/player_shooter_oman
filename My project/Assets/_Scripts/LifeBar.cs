using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Life targetLife;


    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = targetLife.amount / targetLife.GetInitialLife();
    }


}
