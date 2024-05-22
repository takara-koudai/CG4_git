using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public GameObject block;

    public GameObject goal;

    public GameObject clearText;

    //マップ(ステージ)
    int[,] map =
    {
        {1,0,0,1,1,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 2,2,0,0,0,0,2,0,0,0, 0,0,0,0,1,1,0,0,0,1},
        {1,0,0,1,1,0,0,0,0,0, 0,0,1,1,0,0,0,0,0,0, 1,1,0,0,0,0,1,0,0,0, 0,0,0,0,0,0,0,0,3,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,1,1},
        {1,0,0,0,0,0,1,1,0,0, 0,0,0,0,0,0,2,0,0,0, 0,0,0,2,2,0,0,0,0,0, 1,1,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,1,1,0,0,0, 0,0,0,1,1,0,0,0,0,0, 0,0,0,0,0,1,1,0,0,1},
        {1,0,0,0,1,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,0,0, 0,0,0,0,1,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,0,0,1,1,1, 1,1,1,1,1,1,1,1,1,1, 0,0,1,1,0,0,1,1,0,1, 0,0,1,0,0,1,1,1,1,1},
    };

    // Start is called before the first frame update
    void Start()
    {

        Vector3 position = Vector3.zero;

        //ブロック描画
        for(int x = 0;x < 40;x++)
        {
            for(int y = 0;y < 10;y++)
            {
                position.x = x;
                position.y = -y + 5;

                if (map[y,x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                if (map[y,x] == 3)
                {
                    goal.transform.position = position;
                }
            }
        }

        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);

    }

    // Update is called once per frame
    void Update()
    {
        //ゴールしてSpaceを押すとタイトルへ戻る
        if(GoalScript.isGameClear == true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}
