using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Rigidbody rb;
    private AudioSource audioSource;

    public Animator animator;

    public GameObject bombParticle;

    float movespeedJamp = 8f;
    float movespeed = 4f;

    private bool isJamp;

    private void OnCollisionStay(Collision collision)
    {
        isJamp = true;

        animator.SetBool("jump", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        isJamp = false;
    }
    
    void Start()
    {
        //音を鳴らす
        audioSource = gameObject.GetComponent<AudioSource>();

        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    //コインとの衝突フラグ
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.SetActive(false);

        if(other.gameObject.tag == "Coin")
        {
            //スコアを増やす
            other.gameObject.SetActive(false);
            GameManagerScript.score += 1;

            //ここにコインを取った時の音を入れる
            audioSource.Play();

            //爆発パーティクル発生
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        if(GoalScript.isGameClear == false)
        {

            //左右に動く
            Vector3 v = rb.velocity;
            float stick = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
            {
                v.x = movespeed;
                transform.rotation = Quaternion.Euler(0, 90, 0);

                animator.SetBool("walk", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                v.x = -movespeed;
                transform.rotation = Quaternion.Euler(0, -90, 0);

                animator.SetBool("walk", true);
            }
            else
            {
                v.x = 0;

                animator.SetBool("walk", false);
            }

            
            //ジャンプ(一回だけしか飛ばない)
            if(isJamp && Input.GetKey(KeyCode.Space))
            {

                if(isJamp)
                {
                    animator.SetBool("jump", true);
                }
                else
                {
                    animator.SetBool("jump", false);
                }

                v.y = movespeedJamp;
            }

            //PADでのジャンプ
            if(isJamp && Input.GetButton("Jump"))
            {
                if (isJamp)
                {
                    animator.SetBool("jump", true);
                }
                else
                {
                    animator.SetBool("jump", false);
                }

                v.y = movespeedJamp;
            }

            rb.velocity = v;
        }
    }
}
