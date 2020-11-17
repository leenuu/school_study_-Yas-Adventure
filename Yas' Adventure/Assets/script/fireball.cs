using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    // Start is called before the first frame update
    private float d_time = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        d_time += Time.deltaTime;
        if(d_time >= 0.6f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "test")
            Destroy(gameObject);
        if (collision.gameObject.tag == "ex")
            Destroy(gameObject);
        if (collision.gameObject.tag == "gost")
            Destroy(gameObject);
        if(collision.gameObject.tag == "wall")
            Destroy(gameObject);               
         
    }
}


