using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrow : MonoBehaviour
{
    //*WARNING* This code is fucked up.

    public float spearSpeed;
    public float rotSpeed;
    public float retrieveSpeed;

    public Transform pointer;
    public Transform player;

    public GameObject brushCircle;

    private bool fire = false;

    private Rigidbody2D rigid;
    private BoxCollider2D box;
    private CircleCollider2D retrieve;

    //WEST TEST
    [SerializeField] private bool useSpearLine;
    [SerializeField] private int lineCnt;
    [SerializeField] private Transform spearForward;
    [SerializeField] private LineRenderer line;
        //rigid.MovePosition()
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        retrieve = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        float deg = Mathf.Atan2(pointer.position.y - transform.position.y, pointer.position.x - transform.position.x) * Mathf.Rad2Deg;
        Vector3 destin = new Vector2(player.position.x, player.position.y + 2.2f);

        if (useSpearLine)
        {
            for (int i = 0; i < lineCnt; i++)
            {
                float t = (float)i / lineCnt;

                Vector2 bezierline = Bezier(transform.position, spearForward.position,
                    pointer.position, new Vector2(pointer.position.x, -10), t);

                line.SetPosition(i, bezierline);
            }
        }

        if (rigid.bodyType != RigidbodyType2D.Static)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                rigid.velocity = transform.right * spearSpeed;
                rigid.bodyType = RigidbodyType2D.Dynamic;
                fire = true;
            }

            if (!fire)
            {
                //box.isTrigger = true;

                rigid.bodyType = RigidbodyType2D.Kinematic;

                transform.position = Vector2.Lerp(transform.position, destin, Time.deltaTime * retrieveSpeed);
                
                //transform.position = new Vector2(player.position.x, player.position.y + 1.8f);

                transform.rotation = Quaternion.Euler(0, 0, deg);
                
            }
            else
            {
                //transform.right = rigid.velocity * 0.8f;
                transform.right = rigid.velocity;
                Instantiate(brushCircle, transform.position, transform.rotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && rigid.bodyType == RigidbodyType2D.Dynamic)
        {
            rigid.bodyType = RigidbodyType2D.Static;
            box.isTrigger = true;
            retrieve.enabled = true;
            //fire = false;
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Boundary")
        {
            rigid.bodyType = RigidbodyType2D.Kinematic;
            box.isTrigger = false;
            fire = false;
            retrieve.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            rigid.bodyType = RigidbodyType2D.Kinematic;
            box.isTrigger = false;
            fire = false;
        }
    }

    private Vector2 Bezier(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
    {
        Vector2 vecterA = Vector2.Lerp(a, b, t);
        Vector2 vecterB = Vector2.Lerp(b, c, t);
        Vector2 vecterC = Vector2.Lerp(c, d, t);

        Vector2 vectorX = Vector2.Lerp(vecterA, vecterB, t);
        Vector2 vectorY = Vector2.Lerp(vecterB, vecterC, t);

        return Vector2.Lerp(vectorX, vectorY, t);
    }
}
