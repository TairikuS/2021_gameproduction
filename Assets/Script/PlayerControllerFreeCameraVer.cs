using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFreeCameraVer : MonoBehaviour
{
    enum Direction
    {
        None,
        Up,
        Right,
        Down,
        Left,
    }

    [Header("ポーズ画面表示の時は音を鳴らさない")]
    public GameObject pouseObject;

    public AudioSource walksound;

    public GameObject animObject;
    Animator walkAnim;

    public float speed = 5f;

    //ジャンプパワーの初期設定
    float jumpPower = 0f;
    public float deltaJumpPower = 1f;
    public float jumpPowerMax = 32f;

    public bool grounded = false;

    public GameObject particle;

    public Transform groundPos;

    public LayerMask ground;


    bool isSpeed = false;
    //操作可能かどうか
    bool OperationPossible = true;

    public bool canMove = false;

    //クールタイム
    float coolTime = 0;
    [Header("敵の球に当たったときのクールタイム")]
    public float coolTimePoint = 3.0f;

    Rigidbody rg;


    // Start is called before the first frame update
    void Start()
    {
        //60フレーム指定されたので
        Application.targetFrameRate = 60;
        rg = gameObject.GetComponent<Rigidbody>();
        walkAnim = animObject.GetComponent<Animator>();
        walkAnim.speed = 0f;
        walksound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //スティックの入力
        float verticalLeft = Input.GetAxis("L_Vertical");
        float horizontalLeft = Input.GetAxis("L_Horizontal");

        //地面にいない時、攻撃を受けているとき、開始前など動かないようにする
        if (grounded && OperationPossible && canMove)
        {
            //小さい入力を感知してしまう可能性があるので
            if (Mathf.Abs(new Vector2(verticalLeft, horizontalLeft).magnitude) > 0.5f)
            {

                //カメラの向きからプレイヤーの向きを調べ進む方向を確定させる
                Vector3 playerForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
                Vector3 moveForward = playerForward * -verticalLeft + Camera.main.transform.right * horizontalLeft;

                rg.velocity = moveForward * speed;
                //プレイヤーの向きを進む方向に合わせる
                transform.rotation = Quaternion.LookRotation(moveForward);

                walkAnim.speed = 1f;

                //歩くSE
                if (!walksound.isPlaying && !pouseObject.activeSelf)
                {
                    walksound.Play();
                }
            }
            else
            {
                rg.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                walkAnim.speed = 0f;
                walksound.Stop();
            }

        }

        //弾に当たったときのクールタイム
        if (!OperationPossible)
        {
            coolTime += Time.deltaTime;
            rg.constraints = RigidbodyConstraints.FreezeAll;
            walkAnim.speed = 0f;
            if (coolTime > coolTimePoint)
            {
                //FreezeRotationZ,FreezeRotationXをオンにする
                rg.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                OperationPossible = true;
                coolTime = 0.0f;
            }
        }
    }

    [System.Obsolete]
    private void FixedUpdate()
    {

        if (Physics.Raycast(groundPos.position, Vector3.down, 0.1f, ground))
        {
            grounded = true;
            isSpeed = false;
        }
        else
        {
            grounded = false;
            if (!isSpeed)
            {
                rg.AddForce(transform.TransformDirection(new Vector3(0, 0, 2.0f)), ForceMode.Impulse);
                isSpeed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //何処にこれ入れようか迷ったのでここに置いときました
        //敵の弾に当たるとはじき飛びます
        if (other.tag == "shotBall" && OperationPossible)
        {
            //var rb = GetComponent<Rigidbody>();

            //Vector3 vector = gameObject.transform.position - other.transform.position;
            //rb.AddForce(vector.normalized * 6, ForceMode.Impulse);

            OperationPossible = false;
        }
    }

    void CanMove(bool CanMove)
    {
        canMove = CanMove;
    }
}