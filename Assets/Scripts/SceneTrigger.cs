using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    // Name of the scene to load when triggered
    public string nextSceneName;

    // This method is called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that triggered the collider is the one you're expecting
        if (other.CompareTag("PlayerShipTag"))  // Replace "Player" with the tag of the object that triggers the scene change
        {
            // Load the scene with the specified name
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
