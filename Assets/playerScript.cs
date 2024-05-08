using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Rigidbody rb;

    float movespeed = 4f;

    private bool isJamp;

    //private void OnCollisionStay(Collision collision)
    //{
    //    isJamp = true;
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    isJamp = false;
    //}

    private void OnCollisionExit(Collision collision)
    {
        isJamp = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ç∂âEÇ…ìÆÇ≠
        Vector3 v = rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = movespeed;
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -movespeed;
        }
        else
        {
            v.x = 0;
        }

        //ÉWÉÉÉìÉv
        if(Input.GetKey(KeyCode.Space))
        {
            v.y = movespeed;
        }

        /*if(isJamp && Input.GetKey(KeyCode.Space))
        {
            float dist = v.y - movespeed;
            if(dist < movespeed)
            {
                return;
            }
            rb.velocity = v;
        }*/

        rb.velocity = v;


    }
}
