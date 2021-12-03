using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Player;  //追いたいオブジェクト(Player)と紐づける
    public float CameraX;  //Inspector上で追いたい距離間を入力
    public float CameraY;
    public float CameraZ;

    void Update()
    {
        Vector3 Pos = Player.transform.position;  //座標を取得する
        transform.position = new Vector3(Pos.x + CameraX, Pos.y + CameraY, Pos.z + CameraZ);  //Playerとカメラの位置を同じにする
    }
}
