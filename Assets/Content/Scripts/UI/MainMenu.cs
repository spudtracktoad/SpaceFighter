using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Button StartButton;

    // Start is called before the first frame update
    void Start()
    {
        StartButton = StartButton.GetComponent<Button>();
        StartButton.onClick.AddListener(startBtnOnClick);
        Cursor.visible = true;
    }

    void startBtnOnClick()
    {
        SceneManager.LoadScene("FlightTest");
    }
}
