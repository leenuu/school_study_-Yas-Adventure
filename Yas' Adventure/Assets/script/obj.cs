using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject cam_obj;
    private float obj_speed = 12.0f;
    private float d_time = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        d_time += Time.deltaTime;
        if(d_time >= 0.8f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * Time.deltaTime * obj_speed);
    }
}
