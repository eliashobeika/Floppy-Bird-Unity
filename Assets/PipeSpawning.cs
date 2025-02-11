using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawning : MonoBehaviour
{
    public GameObject pipe;
    public float spawnrate = 1;
    private float Timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < spawnrate)
            Timer += Time.deltaTime;
        else
        {
            spawnPipe();
            Timer = 0;
        }
    }
    void spawnPipe()
    {
        float highestpoint = transform.position.y + heightOffset;
        float lowestpoint = transform.position.y - heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), 0), transform.rotation);
    }
 
}
