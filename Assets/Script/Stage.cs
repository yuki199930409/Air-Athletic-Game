using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private Vector3 StagePos;  //座標を取得

    void Start()
    {
        StagePos = transform.position;  //現在の位置
    }

    void Update()
    {
        if (gameObject.tag == "Stage00")
        {
            transform.position = new Vector3(Mathf.Sin(Time.time) * -7.0f + StagePos.x, StagePos.y, StagePos.z);  //Stage00タグついてたら左右に移動
        }
        if (gameObject.tag == "Stage01")
        {
            transform.position = new Vector3(Mathf.Sin(Time.time) * -3.0f + StagePos.x, StagePos.y, StagePos.z);  //Stage1タグついてたら左右に移動
        }
        if (gameObject.tag == "Stage02")
        {
            transform.position = new Vector3(Mathf.Sin(Time.time) * 3.0f + StagePos.x, StagePos.y, StagePos.z);  //Stage02タグついてたら右左に移動
        }
        if (gameObject.tag == "Stage03")
        {
            transform.position = new Vector3(Mathf.Sin(Time.time) * 7.0f + StagePos.x, StagePos.y, StagePos.z);  //Stage03タグついてたら右左に移動
        }
        if (gameObject.tag == "Stage04")
        {
            transform.position = new Vector3(StagePos.x, StagePos.y, Mathf.Sin(Time.time) * -7.0f + StagePos.z);  //Stage04タグついてたら下上に移動
        }
        if (gameObject.tag == "Stage05")
        {
            transform.position = new Vector3(StagePos.x, Mathf.Sin(Time.time) * -7.0f + StagePos.y, StagePos.z);  //Stage05タグついてたら低高に移動
        }
        if (gameObject.tag == "Stage06")
        {
            transform.position = new Vector3(StagePos.x, StagePos.y, Mathf.Sin(Time.time) * 7.0f + StagePos.z);  //Stage06タグついてたら上下に移動
        }
    }
}