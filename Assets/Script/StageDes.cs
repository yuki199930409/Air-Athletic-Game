using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDes : MonoBehaviour
{
    private int status;
    private float time;
    public Player pl;
    private GameObject Master;

    void OnCollisionStay(Collision collision)
    {
        if (status == 0)  //開始時は0だからコライダーと接触したらstatusは1になる
        {
            status = 1;
        }
    }

    void Start()
    {
        status = 0;
        time = 0;

        Master = GameObject.Find("Player");  //Playerオブジェクトを探す
        pl = Master.GetComponent<Player>();
    }

    void Update()
    {
        if (status == 1)  //コライダーと接触した時は1になると
        {
            time += Time.deltaTime;  //timeにTime.deltaTimeが足されていく

            if (time > 0.5f)  //床と接触している時、0.5秒経つと
            {
                 pl.StageDestroy();  //Playerの中のStagedestroy関数が呼ばれる
                 Destroy(this.gameObject);  //コライダーと触れている時、0.5秒後に床は消える
                 status = 2;
            }
        }
    }
 }
