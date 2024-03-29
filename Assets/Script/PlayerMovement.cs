using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public float gizmoDelay;

    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D rigid;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private int gravityGizmo = 1;
    private float delayTime;

    private enum MovementState { idle, run, jump, fall }

    private float moveH = 0f;

    //---TEST---//
    public bool gizmoActivate;
    private BoxCollider2D boxCollider;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //---TEST---//
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //GetComponent<Renderer>().sortingOrder = 1;

        moveH = Input.GetAxisRaw("Horizontal");
        if (rigid.bodyType != RigidbodyType2D.Static)
            rigid.velocity = new Vector2(moveH * moveSpeed, rigid.velocity.y);

        //키 입력칸
        if (Input.GetButtonDown("Fire2") && isGrounded() && delayTime < Time.time && gizmoActivate)
        {
            delayTime = gizmoDelay + Time.time;
            gravityGizmo *= -1;
            rigid.gravityScale = 4 * gravityGizmo;
            if (gravityGizmo == -1)
                sprite.flipY = true;
            else
                sprite.flipY = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded() && rigid.bodyType != RigidbodyType2D.Static)
        {
            rigid.velocity = new Vector3(0, jumpPower * gravityGizmo, 0);
        }

        //Vector2 scale = transform.localScale;
        //boxCollider.size = new Vector2(scale.x * 2, scale.y * 2);

        UpdateAnim();
    }

    private void UpdateAnim()
    {
        MovementState state;

        if (moveH != 0f)
        {
            state = MovementState.run;
            sprite.flipX = moveH < 0 == true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigid.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rigid.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        //BoxCast에서 바닥에 체크될 때 true를 반환
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down * gravityGizmo, .1f, jumpableGround);
    }

}
