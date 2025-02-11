using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ButtonsScript : MonoBehaviour
{
    public GameObject StartButton;
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null && Input.anyKeyDown)
        {
            EventSystem.current.SetSelectedGameObject(StartButton);
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
