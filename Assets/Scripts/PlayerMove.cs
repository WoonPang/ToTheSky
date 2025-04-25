using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public float Jump;
    public double stopSpeed = 0.3;
    private float LastHorizontalInput = 0;

    public GameManager manager;
    public UIManager uiManager;

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Collider2D collider;
    Animator animator;

    private bool isLanded;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip finishSound;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isLanded)
        {
            if (Input.GetKeyDown("c"))
            {
                rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, Jump);
                animator.SetBool("isJump", true);
                JumpSound();
            }
        }
        if (isLanded)
        {
            animator.SetBool("isJump", false);
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != LastHorizontalInput)
            sprite.flipX = horizontalInput == -1;
        else
            LastHorizontalInput = horizontalInput;

        if (Mathf.Abs(rigid.linearVelocity.x) < stopSpeed)
            animator.SetBool("isMove", false);
        else
            animator.SetBool("isMove", true);
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.linearVelocity.x > Speed)
            rigid.linearVelocity = new Vector2(Speed, rigid.linearVelocity.y);
        else if (rigid.linearVelocity.x < Speed * (-1))
            rigid.linearVelocity = new Vector2(Speed * (-1), rigid.linearVelocity.y);

        Vector2 rayOrigin = new Vector2(collider.bounds.center.x, collider.bounds.min.y);
        RaycastHit2D rayHit = Physics2D.Raycast(rayOrigin, Vector2.down, 0.5f, LayerMask.GetMask("Land"));

        if (rayHit.collider != null)
        {
            isLanded = true;
        }
        else
        {
            isLanded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            GameObject.Find("PlayTime").GetComponent<PlayTime>().StopTimer();

            Debug.Log("Finish 라인 도달 - 시간 멈춤, 게임 정지");

            Time.timeScale = 0f;

            FinishSound();

            uiManager.GameFinishUI();
        }
    }

    public void FinishSound()
    {
        audioSource.PlayOneShot(finishSound);
    }
}

