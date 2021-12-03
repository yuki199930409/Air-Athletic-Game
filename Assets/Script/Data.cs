using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public Life[] life;
    public Vector3 coordinate;  //座標を取得する
    public int firsttimeflg;
    public int Hp;
    public GameObject StageObject;  //Prefab化したStageと紐づける
    public GameObject StageObjecti;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //シーン遷移したら引き継ぐことが出来る
        firsttimeflg = 0;
        StageObjecti = Instantiate(StageObject);
        Hp = 0;
    }

    public void StageSet()
    {
        Destroy(StageObjecti);
        StageObjecti = Instantiate(StageObject);  //ゲーム中にStageオブジェクトを生成する
    }

    public void LifeDes()
    {
        life[Hp].Lifedes();  //Lifedesが実行されてlifeの該当の配列のみ消える
        Hp += 1;  //実行される度にHpに1が足されていく
    }
}
