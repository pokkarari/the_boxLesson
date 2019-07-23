using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //定数定義：壁方向
    public const int WALL_FRONT = 1;    //前
    public const int WALL_RIGHT = 2;    //右
    public const int WALL_BACK = 3;     //後
    public const int WALL_LEFT = 4;     //左


    //定数定義：ボタンカラー
    public const int COLOR_GREEN = 0;   //緑
    public const int COLOR_RED = 1;     //赤
    public const int COLOR_BLUE = 2;    //緑
    public const int COLOR_WHITE = 3;   //白


    public GameObject panelWalls;       //壁全体

    public GameObject buttonHammer;     //ボタン：トンカチ
    public GameObject imageHammerIcon;  //アイコン；トンカチ

  
    public GameObject buttonMessage;    //ボタン：メッセージ
    public GameObject buttonMessageText;//メッセージテキスト

    public GameObject[] buttonLamp = new GameObject[3];//ボタン：金庫
    public Sprite[] buttonPicture = new Sprite[4]; //ボタンの絵
    public Sprite　hammerPicture; //トンカチの絵


    private int wallNo;                 //現在の向いている方向
    private bool doseHavaHammmer;       //トンカチを持っているか？
    private int[] buttonColor = new int[3]; //金庫のボタン



    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;      //スタート時点では前を向く
        doseHavaHammmer = false;  //トンカチは「持っていない」

        buttonColor[0] = COLOR_GREEN; //ボタン1の色は「緑」
        buttonColor[1] = COLOR_RED;  //ボタン2の色は「赤」
        buttonColor[2] = COLOR_BLUE; //ボタン3の色は「青」
    }

    // Update is called once per frame
    void Update()
    {

    }

    //メモをタップ
    public void PushButtonMemo()
    {
        DisplayMessage("エッフェル塔と書いてある");

    }

    //トンカチの絵をタップ
    public void PushButtonHammer()
    {
        buttonHammer.SetActive(false);
    }


    //メッセージをタップ
    public void PushButtonMessage()
    {
        //メッセージを消す
        buttonMessage.SetActive(false);  
    }




    //左右への移動スクリプト
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


    //メッセージの表示
    void DisplayMessage(string mes)
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }




    //向いている方向の壁を表示　
    //localPositionはピポット（基準位置）の左表を表す
    //カメラを移動する感じ。実際はパネルの上の壁CanvasGameのPanelWallsが
    //-1000,-2000,-3000と切り替わっていく
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


    //金庫のボタン1をタップ
    public void PushButtonLamp1()
    {
        ChangButtonColor(0);
    }
    //金庫のボタン2をタップ
    public void PushButtonLamp2()
    {
        ChangButtonColor(1);
    }
    //金庫のボタン3をタップ
    public void PushButtonLamp3()
    {
        ChangButtonColor(2);
    }

    //金庫のボタンの色を変更
    void ChangButtonColor (int buttonNo)
    {
        buttonColor[buttonNo]++;
        //「白」のときにボタンを押したら「緑」
        if(buttonColor[buttonNo] > COLOR_WHITE)
        {
            buttonColor[buttonNo] = COLOR_GREEN;
        }

        //ボタンの画像を変更
        buttonLamp[buttonNo].GetComponent <Image>().sprite =
            buttonPicture[buttonColor[buttonNo]];

        //ボタンの色順をチェック
        if((buttonColor[0] == COLOR_BLUE) && (buttonColor[1] == COLOR_WHITE) && (buttonColor[2] == COLOR_RED)){
            //まだトンカチ持っていない？
            if(doseHavaHammmer == false)
            {
                DisplayMessage("金庫にトンカチが入っていた");
                buttonHammer.SetActive(true); //トンカチの絵を表示
                imageHammerIcon.GetComponent<Image>().sprite = hammerPicture;

                doseHavaHammmer = true;
            }
        }
    }


}
