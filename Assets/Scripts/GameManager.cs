﻿using System.Collections;
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

    //右(>)ボタンを押した
    public void PushButtonRight()
    {
        wallNo++; //方向を1つ右に
        //「左」の1つ右は「前」
        if(wallNo > WALL_LEFT)
        {
            wallNo = WALL_FRONT;
        }

        DisplayWall(); //壁表示の更新
    }


    //左(>)ボタンを押した
    public void PushButtonLeft()
    {
        wallNo--; //方向を1つ左に
        //「前」の1つ左は「左」
        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEFT;
        }

        DisplayWall(); //壁表示の更新
    }

    //向いている方向の壁を表示　
    //localPositionはピポット（基準位置）の左表を表す
    //カメラを移動する感じ。-1000,-2000,-3000と切り替わっていく
    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT: //前
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT: //右
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK: //後
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT: //左
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;

        }
    }


}
