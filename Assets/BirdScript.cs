using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public SpriteRenderer Birdrender;
    public Rigidbody2D BirdBody;
    public float FlapStrength;
    public LogicScript LogicScript;
    public bool BirdisAlive = true;
    public Sprite deadbird;
    public Animator WingsAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) == true || Input.GetKeyDown(KeyCode.Space) == true) && BirdisAlive == true && Time.timeScale == 1)
            BirdBody.velocity = new Vector2(0, FlapStrength);
        //wings flapping
        if (BirdisAlive == false)
        {
            WingsAnimator.speed = 0;
        }
    }
    //could move the dead bird's death animation (sprite change) to logicscript one day, but its alright for now
    //highscore saving is here so that it saves only once instead of everytime a highscore is set (so every turn after high is surpassed)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LogicScript.highscore == LogicScript.score)
        {
            PlayerPrefs.SetInt("Highscore", LogicScript.highscore);
        }
        Birdrender.sprite = deadbird;
        LogicScript.gameover();
        BirdisAlive = false;
       
    }
}
