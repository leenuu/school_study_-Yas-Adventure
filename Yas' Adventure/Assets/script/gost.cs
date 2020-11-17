using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gost : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer SpriteRenderer;

    private float hp = 30.0f;
    private float speed = 3.5f;
    private float cos;
    private float sin;
    private Vector2 playerpos;
    private GameObject player;
    private float dot_d = 0.0f;
    private int dot_c = 0;
    private bool fire_dot = false; 
    private int po_st = 0;
    private float po_d = 0.0f;
    private void Awake()

    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }
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
        if(hp <= 0.01f)
            Destroy(gameObject);
        move();
        dot_dam();
        Debug.Log(po_st);
        po_d += Time.deltaTime;
        if(po_st == 5 && po_d >= 3.0f)
        {
            po_d = 0.0f;
            po_st--;    
            Debug.Log("st--"); 
        }
        else if(po_d >= 0.9f && po_st >= 1 && po_st <= 4)
        {
            po_d = 0.0f;
            po_st--;    
            Debug.Log("st--");      
        }
        
    // Debug.Log(hp);
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
            if(po_st == 0)
                hp = hp - 10.0f * player.GetComponent<player>().cri;
            else
                 hp = hp - 10.0f * player.GetComponent<player>().cri * (1 + 0.04f * po_st);
            
            fire_dot = true;
            
            float back_v = 5.0f;
            transform.Translate(-transform.position.x * back_v * Time.deltaTime , -transform.position.y * back_v * Time.deltaTime , 0);
                               
        }

        if(collision.gameObject.tag == "pl")
        {
            Debug.Log("tag");

            player = GameObject.FindGameObjectWithTag("pl");
            float back_v = 35.0f;
            player.transform.Translate(playerpos.x * back_v * Time.deltaTime - player.GetComponent<player>().back_x, playerpos.y * back_v * Time.deltaTime - player.GetComponent<player>().back_y, 0);
        }

        if(collision.gameObject.tag == "pos")
        {   
    
            if(po_st == 0)
                hp = hp - 10.0f * player.GetComponent<player>().cri;
            else
                hp = hp - 10.0f * player.GetComponent<player>().cri * (1 + 0.04f * po_st);
            if(po_st < 5)
                po_st ++;  
            else if(po_st == 5)
                po_st = 5; 
                
            float back_v = 5.0f;
            transform.Translate(-transform.position.x * back_v * Time.deltaTime , -transform.position.y * back_v * Time.deltaTime , 0);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

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
        if(dot_d >= 0.94f)
        {
            if(po_st == 5)
                hp -= 0.6f;
            else
                hp -= 0.4f;
            dot_c ++;
            dot_d = 0.0f;
            StartCoroutine("hit_f");  
        }
        

    }

    private IEnumerator hit_f()
    {
        int countTime = 0;

        while (countTime < 2){
            if(countTime%2 == 0)
                SpriteRenderer.color = new Color32(255,90,90,255);
            else
                SpriteRenderer.color = new Color32(255,255,255,255);

            yield return new WaitForSeconds(0.15f);

            countTime++;
        }

    }

    private IEnumerator hited()
    {
        int countTime = 0;

        while (countTime < 9){
            if(countTime%2 == 0)
                SpriteRenderer.color = new Color32(255,255,255,90);
            else
                SpriteRenderer.color = new Color32(255,255,255,180);

            yield return new WaitForSeconds(0.1f);

            countTime++;
        }

        SpriteRenderer.color = new Color32(255,255,255,255);
    }

 }
