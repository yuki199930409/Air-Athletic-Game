using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float JumpPawer = 300f; //上方向にかける力
    private bool Jump; //着地しているかどうかの判定
    private float Goal;
    public Life[] life;
    private int lifee;
    public Data Data;
    private GameObject Master;
    public GameObject Pr;
    public Transform m_palent;  
    public AudioClip sound;
    public AudioSource audioSource;

    void OnCollisionStay(Collision collision)
    {
        //Stage00、Stage01、Stage02、Stage03、Stage04、Stage05、Stage06タグであれば
        if (collision.gameObject.tag == "Stage00" || collision.gameObject.tag == "Stage01"
            || collision.gameObject.tag == "Stage02" || collision.gameObject.tag == "Stage03"
            || collision.gameObject.tag == "Stage04"|| collision.gameObject.tag == "Stage05"
            || collision.gameObject.tag == "Stage06")
        {
            //移動する床に乗っている時はPlayerも一緒に移動したいのでgameObjectの入れ子にする
            transform.parent = collision.gameObject.transform;
        }
        
        if (collision.gameObject.tag == "Stage07")
        {   
            GameObject.Find("FourFloor").transform.Find("GOAL").gameObject.SetActive(true);  //Stage07タグに乗ったら非表示から表示にする

            Goal += Time.deltaTime;  //GoalにTime.deltaTimeが足されていく

            if (Goal >= 3.0f)  //Goalの床に乗ってから3秒後にシーン遷移される
            {
                SceneManager.LoadScene("Goal");
            }
        }
    }

    void OnCollisionExit()
    {
        transform.parent = null;  //床から離れた時は入れ子から外に出す
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Goal = 0;
        lifee = 0;

        Master = GameObject.Find("Data");  //Dataを見つける
        Data = Master.GetComponent<Data>();

        //Dataの中のfirsttimeflgが0でなければ実行される(チェックポイントを通過すると実行される)
        if (Data.firsttimeflg != 0)
        {
            this.transform.position = Data.coordinate;  //座標を覚える
        }
    }

    void Update()
    {
        int flg = 0;
        rb.WakeUp();  //オブジェクトが停止しているかどうかを判定する

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.x < 10.0f)
            {
                rb.AddForce(new Vector3(10.0f, 0.0f, 0.0f));  //→を押したら右方向へ進む
            }
            flg = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))  
        {
            if (rb.velocity.x > -10.0f)
            {
                rb.AddForce(new Vector3(-10.0f, 0.0f, 0.0f));  //←を押したら左方向へ進む
            }
            flg = 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))  
        {
            if (rb.velocity.z < 10.0f)
            {
                rb.AddForce(new Vector3(0.0f, 0.0f, 10.0f));  //↑を押したら上方向へ進む
            }
            flg = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))  
        {
            if (rb.velocity.z > -10.0f)
            {
                rb.AddForce(new Vector3(0.0f, 0.0f, -10.0f));  //↓を押したら下方向へ進む
            }
            flg = 1;
        }

        if (flg == 0)
        {
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }

        if (Jump == true)  //着地している時はtrueになるので下記が実行される
        {
            if (Input.GetKeyDown("space"))  //スペースキーを押したらジャンプする
            {
                Jump = false;  //2回以上ジャンプさせないため
                rb.AddForce(new Vector3(0, JumpPawer, 0));  //上に向かって力を加える
            }
        }

        if (transform.position.y < -5.0f)  //position.yが-5.0以下になれば
        {
            this.transform.position = Data.coordinate;  //ステージから落ちたらDataの中の座標を取得した位置に戻る

            if (Data.Hp == 2)  //Dataの中のHpが2になればシーン遷移される
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                Data.LifeDes();  //Hpが2じゃなければDataの中のLifeDes関数を実行する
                Data.StageSet();  //Hpが2じゃなければDataの中のStageSet関数を実行する
            }
        }
    }

    void OnCollisionEnter(Collision collision)  //床に着地した時はtrueになる
    {
        Jump = true;
    }

    public void StageDestroy()
    {
        transform.parent = m_palent;
    }
}
