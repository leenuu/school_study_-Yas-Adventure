﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    public Animator animator;



    private void Awake()

    {

        animator = GetComponent<Animator>();

    }

    List<string> anim_arr; 
    public GameObject fireball;
    public GameObject iceball;
    public GameObject posball;
    public GameObject thball;

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
    private float speed = 0.007f;
    private float bulletspeed = 10.0f;

    private int test_num = 0;
    private GameObject ball;
    //private int index = 0;

    void Start()
    {
        ball = fireball;


        //ani.Play(anim_arr[0]);
        //ani.wrapMode = WrapMode.Once;
        
        
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
        if(Input.GetKey(KeyCode.F3))
        {
            ball = posball;
        }
        if(Input.GetKey(KeyCode.F4))
        {
            ball = thball;
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
            // pltx.sprite = right_tx; 
            animator.SetBool("ball_right",true);
            rotation.eulerAngles = new Vector3(0, 0, 90);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.right * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
            
        }


        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            
            animator.SetBool("ball_right",false);

        }


        if(Input.GetKey(KeyCode.LeftArrow))
        {
            
            if(fire_del < maxShotDelay)
                return;
            // pltx.sprite = left_tx;
            animator.SetBool("ball_left",true);
            rotation.eulerAngles = new Vector3(0, 180, 90);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.left * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            
            animator.SetBool("ball_left",false);

        }


        if(Input.GetKey(KeyCode.UpArrow))
        {
            
            if(fire_del < maxShotDelay)
                return;
            // pltx.sprite = up_tx;
            animator.SetBool("ball_front",true);
            rotation.eulerAngles = new Vector3(180, 180, 0);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
        }

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            
            animator.SetBool("ball_front",false);

        }


        if(Input.GetKey(KeyCode.DownArrow))
        {
            
            if(fire_del < maxShotDelay)
                return;
            // pltx.sprite = down_tx;
            animator.SetBool("ball_back",true);
            rotation.eulerAngles = new Vector3(0, 180, 0);
            GameObject bullet = Instantiate(ball, transform.position, rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * bulletspeed, ForceMode2D.Impulse);
                
            fire_del = 0;
        }

        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            
            animator.SetBool("ball_back",false);

        }

    }

    void move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
            this.xspeed = this.speed;
            animator.SetBool("right",true);
            
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            
            animator.SetBool("right", false);
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            this.xspeed = -1 * this.speed;
            animator.SetBool("left",true);

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            
            animator.SetBool("left", false);
            
        }

        if (Input.GetKey(KeyCode.W))
        {    
            
            this.yspeed = this.speed;
            animator.SetBool("front",true);

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            
            animator.SetBool("front", false);
            
        }

        if (Input.GetKey(KeyCode.S))
        {
           
            this.yspeed =  -1 * this.speed;
            animator.SetBool("back",true);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            
            animator.SetBool("back", false);
            
        }

        //if(yspeed==0 && xspeed==0)
        



        transform.Translate(this.xspeed, this.yspeed, 0);
        this.xspeed *= 0.96f;
        this.yspeed *= 0.96f;
        // speed_vec.x = Input.GetAxis("Horizontal") * this.speed;
        // speed_vec.y = Input.GetAxis("Vertical") * this.speed;

        // GetComponent<Rigidbody2D>().velocity = speed_vec;
    }
}
