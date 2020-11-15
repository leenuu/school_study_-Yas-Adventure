using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_en : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obj;
    public GameObject player;
    public float hp = 5.0f;
    public float speed = 6;
    public float bulletspeed = 10.0f;
    private float maxShotDelay = 2.0f;
    private float curShotDelay = 1.0f;

    public float cos;
    public float sin;
    private Vector2 playerpos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    void fire()
    {
        curShotDelay += Time.deltaTime;

        playerpos.x = player.transform.position.x - transform.position.x;
        playerpos.y = player.transform.position.y - transform.position.y;

        cos =  Mathf.Cos(Mathf.Atan2(playerpos.y, playerpos.x));
        sin =  Mathf.Sin(Mathf.Atan2(playerpos.y, playerpos.x));
        playerpos.x = cos;
        playerpos.y = sin;
        
        

        if(curShotDelay <= maxShotDelay)
            return;

        GameObject bullet = Instantiate(obj, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        
        rigid.AddForce(playerpos * bulletspeed, ForceMode2D.Impulse);
        curShotDelay = 0.0f;
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
