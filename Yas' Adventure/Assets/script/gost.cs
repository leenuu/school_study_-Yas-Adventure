using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gost : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float hp = 5.0f;
    private float speed = 0.005f;
    public float bulletspeed = 10.0f;
    public float cos;
    public float sin;
    private Vector2 playerpos;
    private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        
        //rigid.AddForce(playerpos * speed, ForceMode2D.Impulse);

        transform.Translate(playerpos.x * speed, playerpos.y * speed, 0);
        //this.speed *= 0.96f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            this.hp -= 1.0f * player.GetComponent<player>().cri;
            if(this.hp <= 0)
                Destroy(gameObject);
        }
    }   
}
