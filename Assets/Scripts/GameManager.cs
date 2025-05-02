using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deadUI;
    Boolean gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKey(KeyCode.R))
        {
            Restart();
        }
        
    }

    public void EndGame()
    {
        deadUI.SetActive(true);
        Time.timeScale = 0f;
        gameOver = true;

    }

    private void Restart()
    {
        deadUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
