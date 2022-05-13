using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //�J�����̋����X�N���v�g�ł��B�v���C���[����������J������^��ɂ���V�X�e���ɂȂ��Ă܂��B
    //�܂��v���C���[���n�ʂɏA�����猳�̈ʒu�ɖ߂�܂��B

    //�v���C���[�{��
    public GameObject target;
    public Out outed;
    public PlayerControllerFreeCameraVer playerController;

    //壁判定
    public LayerMask fall;

    //�J�����̌�������ɂ���
    bool lookUp = false;

    float thardAxis;

    float rad = 0f;

    //�ʒu���i�[����t���O
    bool cameraIntelFlag = false;

    //周りを見渡せるかどうかのフラグ
    bool canMove;
    //�ʒu�Œ�p
    Vector3 num;
    float y;
    //�������W�i�[
    Vector3 initialCoor;
    //������]�p�x
    Vector3 initialRolate;

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

        initialCoor = new Vector3(transform.position.x, y, z);
        initialRolate = transform.localEulerAngles;

        //プレイヤーからカメラまでの斜辺の長さを求める
        //↑カメラの位置が毎ラウンド違うので定数にしました。
        rayCastSize = 10;

        transform.position = new Vector3(target.transform.position.x + 10 * Mathf.Sin(rad * Mathf.Rad2Deg), target.transform.position.y + 6, target.transform.position.z - 10 * Mathf.Cos(rad * Mathf.Rad2Deg));
        canMove = false;
    }

    //���������Ƃ��ɃJ�����K�N�K�N�ɂȂ��Ă��̂�Update���r�I�x�点��֐��ɂ��܂���
    private void LateUpdate()
    {
        thardAxis = Input.GetAxis("Cross_Horizontal");

        //rad += -thardAxis * 0.001f;
        transform.position = new Vector3(target.transform.position.x + 10 * Mathf.Sin(rad * Mathf.Rad2Deg), target.transform.position.y + 6, target.transform.position.z - 10 * Mathf.Cos(rad * Mathf.Rad2Deg));
        if (!lookUp)
        {
            transform.LookAt(target.transform);
        }
        else //�t���O�������Ă���ԏ������
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x - .0f, 0.0f, 0.0f);
        }

        //�J�����̌������v���C���[�ɍ��킹�Ȃ�(�����ɏ����Ă݂�����)
        //switch (turnCount)
        //{
        //    case 0:
        //        //transform.LookAt(target.transform.position);
        //        //transform.rotation = Quaternion.Euler(30f, 0 + 30f * crossHorizontal, 0);
        //        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 3, target.transform.position.z - 5);
        //        break;
        //    case 1:
        //        //transform.LookAt(target.transform.position);
        //        //transform.rotation = Quaternion.Euler(30f, 90f + 30f * crossHorizontal, 0);
        //        //transform.position = new Vector3(target.transform.position.x - 5, target.transform.position.y + 3, target.transform.position.z);
        //        break;
        //    case 2:
        //        //transform.LookAt(target.transform.position);
        //        //transform.rotation = Quaternion.Euler(30f, 180f + 30f * crossHorizontal, 0);
        //        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 3, target.transform.position.z + 5);
        //        break;
        //    case 3:
        //        //transform.LookAt(target.transform.position);
        //        //transform.rotation = Quaternion.Euler(30f, -90f + 30f * crossHorizontal, 0);
        //        //transform.position = new Vector3(target.transform.position.x + 5, target.transform.position.y + 3, target.transform.position.z);
        //        break;
        //}
        //transform.localPosition = initialCoor;//new Vector3(0, 3, - 5);
        //b�{�^���𐄂��Ă���ԏ�������ׂ̃t���O�𗧂Ă�
        //if (Input.GetButton("BtoE"))
        //{
        //    lookUp = true;
        //}
        //else
        //{
        //    lookUp = false;
        //}

        //if (Input.GetButtonDown("AtoQ"))
        //{
        //    turnCount++;
        //    if (turnCount == 4)
        //    {
        //        turnCount = 0;
        //    }
        //}
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            rad += -thardAxis * 0.001f;
        }
        if (false)//outed.outArea)
        {
            lookUp = false;
            transform.LookAt(target.transform);
            num = transform.position;
            num.y = 0.0f;
            transform.position = num;

            cameraIntelFlag = true;
        }
        else
        {
            if (playerController.grounded)
            {
                if (cameraIntelFlag)
                {
                    //�����ʒu�Ɠ������W�ɂȂ��(������Â炢�̂�numFlag����cameraIntelFlag�ɂ��܂���)
                    transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    transform.localEulerAngles = initialRolate;
                    transform.localPosition = initialCoor;
                    cameraIntelFlag = false;
                }
            }

            //�t���O�������Ă�ԏ����������
            if (lookUp)
            {
                //��������΃J�����̌������߂�炵��
                cameraIntelFlag = true;
            }
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

