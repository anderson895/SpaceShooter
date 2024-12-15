using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;
    public bool isMoving;

    Vector2 min;    // Left-bottom boundary
    Vector2 max;    // Right-top boundary

    private GameManager gameManager;  // Reference to GameManager

    void Awake()
    {
        isMoving = false;
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // max.y add half of the Sprite height
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        // min.y subtract half of the Sprite height
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        // Get the GameManager component in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
    }

    void Update()
    {
        if (gameManager != null && gameManager.gameStates != GameManager.GameStates.GamePlay)
        {
            return;  // Do not move the planet if the game is not in GamePlay state
        }

        if (!isMoving)
            return;

        // Get current position, update with speed on Y axis
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        // If the planet goes off the screen
        if (transform.position.y < min.y)
        {
            isMoving = false;
        }
    }

    public void ResetPosition()
    {
        // Random X position
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
