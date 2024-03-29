using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) //Trigger·Î º¯È¯!!
    {
        if (other.gameObject.tag == "Trap")
        {
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D boundary)
    {
        if (boundary.gameObject.tag == "Boundary")
        {
            Die();
        }
    }

    private void Die()
    {
        rigid.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
