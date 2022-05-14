using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    //target == player
    public GameObject target;
    public Out outed;
    public PlayerControllerFreeCameraVer playerController;

    //壁判定
    public LayerMask fall;

    float thardAxis;

    float rad = 0f;

    //周りを見渡せるかどうかのフラグ
    bool canMove;

    //壁用
    float rayCastSize;
    Ray ray;
    RaycastHit hit;
    MeshRenderer mesh;
    float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        float z = Mathf.Pow(transform.position.z, 2) - Mathf.Pow(target.transform.position.z, 2);
        float y = Mathf.Pow(transform.position.y, 2) - Mathf.Pow(target.transform.position.y, 2);

        //プレイヤーからカメラまでの斜辺の長さを求める
        //↑カメラの位置が毎ラウンド違うので定数にしました。
        rayCastSize = 10;

        transform.position = new Vector3(target.transform.position.x + 10 * Mathf.Sin(rad * Mathf.Rad2Deg), target.transform.position.y + 6, target.transform.position.z - 10 * Mathf.Cos(rad * Mathf.Rad2Deg));
        canMove = false;
    }

    private void LateUpdate()
    {
        thardAxis = Input.GetAxis("Cross_Horizontal");

        //rad += -thardAxis * 0.001f;
        transform.position = new Vector3(target.transform.position.x + 10 * Mathf.Sin(rad * Mathf.Rad2Deg), target.transform.position.y + 6, target.transform.position.z - 10 * Mathf.Cos(rad * Mathf.Rad2Deg));

        transform.LookAt(target.transform);

    }
    void FixedUpdate()
    {
        if (canMove)
        {
            rad += -thardAxis * 0.001f;
        }

        //プレイヤーの目の前に壁を表示させないようにする
        ray = new Ray(transform.position, transform.forward);

        //プレイヤーの前までに当たったらその時だけ表示しない(透明度上げる)
        if (Physics.Raycast(ray, out hit, rayCastSize, fall))
        {
            //print("hit");
            //すでに透明なものがあったら表示し直し
            if (mesh != null)
            {
                //透明度を最小にする
                mesh.material.color = new Color(red, green, blue, 255);
                mesh = null;
            }
            mesh = hit.collider.gameObject.GetComponent<MeshRenderer>();
            //カラー格納
            red = mesh.material.color.r;
            green = mesh.material.color.g;
            blue = mesh.material.color.b;
            //透明度最大にする
            mesh.material.color = new Color(red, green, blue, 0);
            //mesh.enabled = false;
        }
        if (mesh != null && !Physics.Raycast(ray, out hit, rayCastSize, fall))
        {
            //透明度を最小にする
            mesh.material.color = new Color(red, green, blue, 255);
            mesh = null;
        }

        //デバッグ
        Debug.DrawRay(ray.origin, ray.direction * rayCastSize, Color.red);
    }

    void CanMove(bool flag)
    {
        canMove = flag;
    }
}

