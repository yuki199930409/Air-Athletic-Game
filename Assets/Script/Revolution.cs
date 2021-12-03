using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
    public float Rev;  //回転の速度

    void Update()
    {
            transform.Rotate(new Vector3(0, Rev, 0));  //Rotation.yを移動する
    }
}
