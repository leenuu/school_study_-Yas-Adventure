using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject obj;
    
    //private Vector2 vec_obj = new Vector2(1.0f, 0.0f); 
    private float fire_del = 2.0f;

    void Start()
    {
        //Instantiate(obj, transform.position, Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }

    void fire()
    {
        fire_del += Time.deltaTime;
        if(fire_del >= 2.0f)
        {
            Instantiate(obj, transform.position, Quaternion.identity); 
            fire_del = 0;
        }
    }
}
