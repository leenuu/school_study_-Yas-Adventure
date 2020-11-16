using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gost : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float hp = 30.0f;
    private float speed = 3.5f;
    private float cos;
    private float sin;
    private Vector2 playerpos;
    private GameObject player;
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(hp);
        // Debug.Log(speed);
        // Debug.Log(speed * Time.deltaTime);
        // Debug.Log(player.GetComponent<player>().cri);
        move();
    }
    void move()
    {
        player = GameObject.FindGameObjectWithTag("pl");
        playerpos.x = player.transform.position.x - transform.position.x;
        playerpos.y = player.transform.position.y - transform.position.y;

        cos =  Mathf.Cos(Mathf.Atan2(playerpos.y, playerpos.x));
        sin =  Mathf.Sin(Mathf.Atan2(playerpos.y, playerpos.x));
        playerpos.x = cos;
        playerpos.y = sin;
        
        
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        
        // rigid.AddForce(playerpos * speed * Time.deltaTime, ForceMode2D.Impulse);

        transform.Translate(playerpos.x * speed * Time.deltaTime, playerpos.y * speed * Time.deltaTime, 0);
        //this.speed *= 0.96f;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "fire")
        {  
            Debug.Log("tag");    
            hp = hp - 10.0f * player.GetComponent<player>().cri;
            Debug.Log(hp);
            if(hp <= 0.0f)
                Destroy(gameObject);
        }

        if(collision.gameObject.tag == "pl")
        {
            Debug.Log("tag");  
            Vector2 back;

            player = GameObject.FindGameObjectWithTag("pl");
            back.x = player.transform.position.x - transform.position.x;
            back.y = player.transform.position.y - transform.position.y;

            float cos_ =  Mathf.Cos(Mathf.Atan2(back.y, back.x));
            float sin_ =  Mathf.Sin(Mathf.Atan2(back.y, back.x));
            float back_v = 35.0f;
            back.x = cos_;
            back.y = sin_;
            
            player.transform.Translate(playerpos.x * back_v * Time.deltaTime, playerpos.y * back_v * Time.deltaTime, 0);
        }

    }

 }
