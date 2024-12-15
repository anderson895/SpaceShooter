using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneRedirectOnClick : MonoBehaviour
{
    // Name of the scene to load when the button is clicked
    public string sceneMainMenu;

    // This method is called when the button is clicked
    public void MainMenu()
    {
        // Load the scene with the specified name
        SceneManager.LoadScene(sceneMainMenu);
    }

    // You can attach this method to the Button's OnClick event in the Inspector
}
