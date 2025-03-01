using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private player_dead playerController;
    public Canvas GameOverCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (playerController != null)
        {
            playerController.PlayerDied += WhenPlayerDies;
        }

        if (GameOverCanvas.gameObject.activeSelf)
        {
            GameOverCanvas.gameObject.SetActive(false);
        }
    }

    void WhenPlayerDies()
    {
        GameOverCanvas.gameObject.SetActive(true);

        if (playerController != null)
        {
            playerController.PlayerDied -= WhenPlayerDies;
        }
    }

    public void RetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
