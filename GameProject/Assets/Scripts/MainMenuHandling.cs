using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandling : MonoBehaviour
{

    public Button btnStartGame;
    public Button btnExitGame;

    // Start is called before the first frame update
    void Start()
    {
        btnStartGame.onClick.AddListener(StartGame);
        btnExitGame.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene("SampleScene");
    }

    void ExitGame()
    {
        Debug.Log("Exit game");
    }
}
