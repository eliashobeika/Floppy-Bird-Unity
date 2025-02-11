using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject ContinueButton;
    public GameObject QuitButton;
    public GameObject Countdown;
    public TextMeshProUGUI CountdownText;
    public GameObject Gameoverscreen;
    void Update()
    {
        //display pause menu
        if ((Input.GetKeyDown(KeyCode.P) == true || Input.GetKeyDown(KeyCode.Escape) == true) && !Gameoverscreen.activeSelf)
        {
            Time.timeScale = 0;
            PauseScreen.SetActive(true);
            ContinueButton.SetActive(true);
            QuitButton.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(ContinueButton);
        }
    }

    IEnumerator CountdownAndResume()
    {
        Countdown.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }

        Time.timeScale = 1;

        Countdown.SetActive(false);
        PauseScreen.SetActive(false);
    }

    public void ContinueGame()
    { 
        ContinueButton.SetActive(false);
        QuitButton.SetActive(false);
        StartCoroutine(CountdownAndResume());
    }
}
