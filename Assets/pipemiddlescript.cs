using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pipemiddlescript : MonoBehaviour
{
    public LogicScript Logic;
    public BirdScript Bird;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logictag").GetComponent<LogicScript>();
        Bird = GameObject.FindGameObjectWithTag("Birdie").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Bird.BirdisAlive == true)
        {
        Logic.addscore();
        Logic.addhighscore();   
        }
       
    }
}
