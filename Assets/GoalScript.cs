using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public GameObject gameClearText;

    public static bool isGameClear = false;

    //private ParticleSystem particle;

    

    private void OnTriggerEnter(Collider other)
    {
        gameClearText.SetActive(true);
        isGameClear = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //タイトルへ戻る
        isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
