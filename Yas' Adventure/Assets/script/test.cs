using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    
    //private Vector2 vec_obj = new Vector2(1.0f, 0.0f); 
    private float hp = 14.0f;
    private float dot_d = 0.0f;
    private int dot_c = 0;
    private bool fire_dot = false; 


    void Start()
    {
        //Instantiate(obj, transform.position, Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp);
        dot_dam();
        if(hp <= 0.01f)
            Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "fire")
        {
            hp -= 10.0f * GameObject.FindGameObjectWithTag("pl").GetComponent<player>().cri;
            fire_dot = true;
        }
    }

    void dot_dam()
    {
        if(fire_dot == false)
            return;
        
        dot_d += Time.deltaTime;
        if(dot_c == 5)
        {
            fire_dot = false;
            dot_c = 0;
            dot_d = 0.0f;
            return;
        }
        if(dot_d >= 1.0f)
        {
            hp -= 0.8f;
            dot_c ++;
            dot_d = 0.0f;
        }
        

    }

}
