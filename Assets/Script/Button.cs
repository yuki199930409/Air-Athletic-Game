using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private float time;
    private bool flg;
    private int keyflg;
    public Data Data;

    public void StartButton()  //StartButtonが押された時、flgはtrueになる
    {
        flg = true;
    }

    public void ButtonClick()  //ButtonClickが押された時、keyflgは1になる
    {
        keyflg = 1;
    }

    void Start()
    {
        time = 0;  //timeを初期化
        flg = false;  //最初はfalse
        keyflg = 0;  //最初は0
    }

    void Update()
    {
        if (flg == true)  //flgがtrueになれば
        {
            time += Time.deltaTime;  //timeにTime.deltaTimeが足されていく

            if (time >= 1.0f)  //ボタンを押して1秒後にシーン遷移される
            {
                SceneManager.LoadScene("GameMain");
                GameObject Data = GameObject.Find("Data");  //Dataオブジェクトを見つける
                Destroy(Data);  //リトライしてGameMainに遷移されるとDataオブジェクトが消える
            }
        }

        if (keyflg == 1)  //keyflgが1になれば
        {
            time += Time.deltaTime;  //timeにTime.deltaTimeが足されていく

            if (time >= 1.0f)  //ボタンを押して1秒後にシーン遷移される
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
