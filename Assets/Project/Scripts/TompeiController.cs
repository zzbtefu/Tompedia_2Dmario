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

    [Header("Components")] 
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Parameters")] 
    public float moveSpeed = 5f;
    private float moveInput;

    [Header("GameObjects")] 
    public GameObject Left_Tompei;
    public GameObject Right_Tompei;

    void Start()
    {
        Left_Tompei.SetActive(false);
        Right_Tompei.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            animator.SetFloat("DirectionX", moveInput);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput < 0)
        {
            Left_Tompei.SetActive(true);
            Right_Tompei.SetActive(false);
        }
        else if (moveInput > 0)
        {
            Left_Tompei.SetActive(false);
            Right_Tompei.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // 0.1秒で最高速度(moveSpeed)に到達するように加速
        // acceleration = moveSpeed / 0.1f
        float targetVelocityX = moveInput * moveSpeed;
        float acceleration = moveSpeed / 0.1f; 
        
        float newVelocityX = Mathf.MoveTowards(rb.velocity.x, targetVelocityX, acceleration * Time.fixedDeltaTime);
        
        rb.velocity = new Vector2(newVelocityX, rb.velocity.y);
    }
}
