using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_skill_ex : MonoBehaviour
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
        if(d_time >= 0.7f)
        {
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "skill")
        {
            Destroy(gameObject);
            //GameObject exp = Instantiate(ex, transform.position, Quaternion.identity);
        }
    }
}
