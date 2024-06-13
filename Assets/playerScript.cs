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
        //����炷
        audioSource = gameObject.GetComponent<AudioSource>();

        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    //�R�C���Ƃ̏Փ˃t���O
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.SetActive(false);

        if(other.gameObject.tag == "Coin")
        {
            //�X�R�A�𑝂₷
            other.gameObject.SetActive(false);
            GameManagerScript.score += 1;

            //�����ɃR�C������������̉�������
            audioSource.Play();

            //�����p�[�e�B�N������
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        if(GoalScript.isGameClear == false)
        {

            //���E�ɓ���
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

            
            //�W�����v(��񂾂�������΂Ȃ�)
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

            //PAD�ł̃W�����v
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
