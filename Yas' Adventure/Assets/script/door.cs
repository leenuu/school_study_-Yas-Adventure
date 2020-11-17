using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator.SetBool("ismonster",false);
    }


    void Update()
    {
        ismonster();
    }

    void ismonster(){
        if(true==true)
        {
            animator.SetBool("ismonster",true);
        }
        else{
            animator.SetBool("ismonster",false);
        }
    }
}
