using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Animator ani;

    public GameObject deadEffect;
    public float jumpForce = 650f;
    bool canJump;
    Rigidbody2D rb;
    public int HP = 50;
    public static bool flashcardused;

    public static bool frezze;
    float frezzeTimer = 5f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

        if(flashcardused) {
            HP -= 15;
            flashcardused = false;
        }

        if(frezze == true) {
            ani.SetBool("isFrezze", true);
            if(frezzeTimer <= 0f) {
                ani.SetBool("isFrezze", false);
                frezzeTimer = -1f;
                frezze = false;
            }else {
                frezzeTimer -= Time.deltaTime;
            }
        }else if(frezze == false) {
            ani.SetBool("isFrezze", false);
            if(canJump) {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
                canJump = false;
            }
        }
        

        if(HP <= 0) {
            AudioManager.PlaySound("dead");
            Destroy(gameObject);
            Instantiate(deadEffect, transform.position, transform.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        canJump = true;
        if(other.collider.tag == "Player") {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.left * 4500f, ForceMode2D.Force);
            Player.health -= 10;
        }
    }
}
