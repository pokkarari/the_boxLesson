using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //定数定義：壁方向
    public const int WALL_FRONT = 1; //前
    public const int WALL_RIGHT = 2; //右
    public const int WALL_BACK = 3; //後
    public const int WALL_LEFT = 4; //左

    public GameObject panelWalls; //壁全体

    private int wallNo;          //現在の向いている方向


    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;      //スタート時点では前を向く
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
