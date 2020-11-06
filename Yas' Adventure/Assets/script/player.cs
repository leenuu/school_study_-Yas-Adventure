using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject fireball;
    public GameObject iceball;
    public SpriteRenderer pltx;

    public Sprite left_tx;
    public Sprite right_tx;
    public Sprite up_tx;
    public Sprite down_tx;
    
    //private Vector2 vec_obj = new Vector2(1.0f, 0.0f); 
    private float fire_del = 2.0f;
    private float xspeed = 0;
    private float yspeed = 0;
    private float maxShotDelay = 0.5f;
    private float speed = 0.01f;
    private float bulletspeed = 10.0f;

    private int test_num = 0;
    private GameObject ball;

    void Start()
    {
        ball = fireball;
        //Instantiate(obj, transform.position, Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        fire();
        move();
        test();
    }

    void test()
    {
        if(Input.GetKey(KeyCode.F1))
        {
            ball = fireball;
        }
        if(Input.GetKey(KeyCode.F2))
        {
            ball = iceball;
        }
    }

    void fire()
    {


        fire_del += Time.deltaTime;
        // if(fire_del >= 2.0f)
        // {
        //     Instantiate(obj, transform.position, Quaternion.identity); 
        //     fire_del = 0;
        // }
        Quaternion rotation = Quaternion.identity;
        


        if(Input.GetKey(KeyCode.RightArrow))
        {
            
            //per = Random.Range(1, 101);
            if(fire_del < maxShotDelay)
                return;
            pltx.sprite = right_tx;    
            rotation.eulerAngles = new Vector3(0, 0, 90);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.right * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
            
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            
            if(fire_del < maxShotDelay)
                return;
            pltx.sprite = left_tx;
            rotation.eulerAngles = new Vector3(0, 180, 90);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.left * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            
            if(fire_del < maxShotDelay)
                return;
            pltx.sprite = up_tx;
            rotation.eulerAngles = new Vector3(180, 180, 0);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            
            if(fire_del < maxShotDelay)
                return;
            pltx.sprite = down_tx;
            rotation.eulerAngles = new Vector3(0, 180, 0);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
        }
    }

    void move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
            this.xspeed = this.speed;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            this.xspeed = -1 * this.speed;
        }
        if (Input.GetKey(KeyCode.W))
        {    
            
            this.yspeed = this.speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
           
            this.yspeed =  -1 * this.speed;
        }

        transform.Translate(this.xspeed, this.yspeed, 0);
        this.xspeed *= 0.96f;
        this.yspeed *= 0.96f;
        // speed_vec.x = Input.GetAxis("Horizontal") * this.speed;
        // speed_vec.y = Input.GetAxis("Vertical") * this.speed;

        // GetComponent<Rigidbody2D>().velocity = speed_vec;
    }
}
