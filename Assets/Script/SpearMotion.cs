using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMotion : MonoBehaviour
{
    [SerializeField] private float spearSpeed;

    [SerializeField] Transform pointer;
    [SerializeField] Transform player;

    private Rigidbody2D rigid;
    private BoxCollider2D box;

    private bool fire = false;

    [SerializeField] private bool useSpearLine;
    [SerializeField] private int lineCnt;
    [SerializeField] private Transform spearForward;
    [SerializeField] private LineRenderer line;

    private Vector3 bezierline;
    //rigid.MovePosition()
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        rigid.bodyType = RigidbodyType2D.Kinematic;
        box.isTrigger = true;
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

                bezierline = Bezier(transform.position, spearForward.position,
                    pointer.position, new Vector2(pointer.position.x, -10), t);

                line.SetPosition(i, bezierline);
            }
        }

        if (rigid.bodyType != RigidbodyType2D.Static)
        {
            if (Input.GetButtonDown("Fire2") && !fire)
            {
                fire = true;
            }

            if (!fire)
            {
                transform.position = Vector2.Lerp(transform.position, destin, 0.8f);
                transform.rotation = Quaternion.Euler(0, 0, deg);
               
            }
            else
            {
                //rigid.MovePosition(bezierline);

                Vector3 direction = bezierline - transform.position;

                if (direction.magnitude > 0.1f)
                {
                    Vector3 moveVector = direction.normalized * spearSpeed * Time.deltaTime;

                    transform.Translate(moveVector);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            fire = false;
        }

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Boundary")
        {
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
