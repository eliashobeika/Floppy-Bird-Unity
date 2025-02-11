using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public int highscore;
    public Text highscoretext;
    public Text ScoreText;
    public AudioSource ding;
    public GameObject GameOverScreen;
    public BirdScript Birdstatus;
    public GameObject PlayAgainButton;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore",0);
        highscoretext.text = "High score: " + PlayerPrefs.GetInt("Highscore", 0);
        Time.timeScale = 1;
    }
    void Update()
    {
       
    }
    [ContextMenu("score and sound")]
    public void addscore()
    {
        score++;
        ScoreText.text = score.ToString();
        ding.Play();
    }
    [ContextMenu("add highscore")]
    public void addhighscore() //high score saving is in birdscript oncollisionenter2d
    {
        if (score > highscore)
        {
            highscore++;
            highscoretext.text = "High score: " + highscore.ToString();
        }
    }
    [ContextMenu("reset high score")]
    public void resethighscore() //high score saving is in birdscript oncollisionenter2d
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Backtotitle()
    {
        SceneManager.LoadScene("Title Scene");
    }
    public float slowdownfactor = 0.5f;
    IEnumerator slowmo()
    {
        yield return new WaitForSeconds(1);
        while (Time.timeScale > 0)
        {
            Time.timeScale -= slowdownfactor * Time.deltaTime;
            yield return null;
        }
        Time.timeScale = 0;
    }
    public void gameover()
    {
        StartCoroutine(slowmo());
        GameOverScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(PlayAgainButton);
    }
}
