using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private Plane _plane;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        _plane.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _plane.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        End();
    }

    private void End()
    {
        Time.timeScale = 0f;
        _gameOverScreen.Show();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}