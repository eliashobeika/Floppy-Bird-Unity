using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public GameObject Top_pipe;
    public GameObject Bottom_pipe;
    public float movespeed = 5;
    private float deadzone = -40;
    private float updeadzone = 8.59f, downdeadzone = -7.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-movespeed, 0, 0) * Time.deltaTime;
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
        if (Top_pipe == null || Bottom_pipe == null)
            return;
        else
        {
            if (transform.position.y > updeadzone)
               Destroy(Top_pipe.gameObject);
            if (transform.position.y < downdeadzone)
              Destroy(Bottom_pipe.gameObject);
        }
        
    }
}
