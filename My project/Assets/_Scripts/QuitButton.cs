using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    Button quitButton;

    private void Awake()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        print("The game is quitting, remember it does not work on the EDITOR!!!!");
        Application.Quit();
    }
}
