using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Plane _plane;

    private void Awake()
    {
        _panel.SetActive(false);
    }

    private void OnEnable()
    {
        _plane.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _plane.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        _panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}