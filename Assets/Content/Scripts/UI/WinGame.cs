using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WinGame : MonoBehaviour
{
    public Button QuitGameButton;
    public Button RestartButton;
    public Button NextLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        QuitGameButton = QuitGameButton.GetComponent<Button>();
        RestartButton = RestartButton.GetComponent<Button>();
        NextLevelButton = NextLevelButton.GetComponent<Button>();
        NextLevelButton.onClick.AddListener(NextLvlBtnOnClick);
        QuitGameButton.onClick.AddListener(quitBtnOnClick);
        RestartButton.onClick.AddListener(restartBtnOnClick);
        Cursor.visible = true;

    }

    void quitBtnOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void NextLvlBtnOnClick()
    {
        SceneManager.LoadScene("FlightTest");
    }

    void restartBtnOnClick()
    {
        SceneManager.LoadScene("FlightTest");
    }
}
