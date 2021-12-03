using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Data Cp;
    private GameObject Master;

    void Start()
    {
        Master = GameObject.Find("Data");  //Dataオブジェクトを見つける
        Cp = Master.GetComponent<Data>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Cp.coordinate = this.transform.position;  //座標を覚える
        Cp.firsttimeflg = 1;  //チェックポイントに当たったら1になる
        Destroy(this.gameObject);  //チェックポイントに当たったら消える
    }

}
