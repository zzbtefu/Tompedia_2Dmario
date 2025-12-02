using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TompeiController : MonoBehaviour
{
    public static TompeiController instance;
    void Awake()
    {
        // 自分自身をinstanceに代入（重複防止の簡易版）
        if (instance == null)
        {
            instance = this;
            // シーン遷移しても壊れないようにする（必要であれば）
            // DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Rigidbody rb;
    private Transform tf;
    private Animator anim;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void FixedUpdate()
    {
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        if (hori != 0 || vert != 0)
        {
            // 移動方向に向けて回転
            Vector3 dir = new Vector3(hori, 0, vert);
            tf.rotation = Quaternion.LookRotation(dir);

            //anim.SetBool("isWalking", true);

            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        else
        {
            // 歩くアニメーション停止
            anim.SetBool("isWalking", false);
        }
    }
}
