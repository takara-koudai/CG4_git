using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Rigidbody rb;

    float movespeedJamp = 8f;
    float movespeed = 4f;

    private bool isJamp;

    private void OnCollisionStay(Collision collision)
    {
        isJamp = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isJamp = false;
    }

    //コインとの衝突フラグ
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        if(other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            //ここにコインを取った時の音を入れる

            GameManagerScript.score += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GoalScript.isGameClear == false)
        {
            //左右に動く
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

            //ジャンプ(一回だけしか飛ばない)
            if(isJamp && Input.GetKey(KeyCode.Space))
            {
                v.y = movespeedJamp;
            }

            //if (Input.GetKey(KeyCode.Space))
            //{
            //    v.y = movespeedJamp;
            //}

            rb.velocity = v;
        }
    }
}
