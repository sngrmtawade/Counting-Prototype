using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _livesText;
    [SerializeField] int _lives;
    [SerializeField] GameObject _enableOnGameOver;
    [SerializeField] GameObject _disableOnStartGame;

    public bool isGameOver = false;
    public bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        _livesText.text = "Lives: " + _lives;
        _enableOnGameOver.SetActive(false);
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_lives <= 0)
        {
            isGameOver = true;
            OnGameOver();
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ChangeLives()
    {
        --_lives;
        _livesText.text = "Lives: " + _lives;
    }
    void OnGameOver()
    {
        _enableOnGameOver.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartGame()
    {
        gameStarted = true;
        _disableOnStartGame.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
