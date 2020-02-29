using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public GameObject deadEffect;

    public Transform playerPos;

    public Transform rightSide;
    public Transform leftSide;
    public Animator ani;
    Rigidbody2D rb;

    float targetRightSide;
    float targetLeftSide;
    public float speed;
    float timer = 1f;
    float time = 1f;

    int EnemyStatus = 1;

    bool faceRight = true;

    public static bool flashcardused;
    public static bool frezze;
    float frezzeTimer = 5f;

    public int HP = 30;
    public static int FlashHP = 30;


    void Start() {
        ani.SetBool("isWalk", false);
        rb = GetComponent<Rigidbody2D>();

        targetRightSide = rightSide.position.x;
        targetLeftSide = leftSide.position.x;

    }

    void Update() {
        
        if(frezze == true) {
            ani.SetBool("isFreeze", true);
            if(frezzeTimer <= 0f) {
                ani.SetBool("isFreeze", false);
                frezze = false;
            }else {
                frezzeTimer -= Time.deltaTime;
            }
        }else if(frezze == false) {
            ani.SetBool("isFreeze", false);
            if(Vector2.Distance(transform.position, playerPos.position) < 5f && Vector2.Distance(transform.position, playerPos.position) > 1f) {
                EnemyStatus = 3;
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);     
                ani.SetTrigger("attack");
            }else if(Vector2.Distance(transform.position, playerPos.position) > 5f) {
                ani.SetBool("isWalk", false);
                if(EnemyStatus == 1) {
                    ani.SetBool("isWalk", false);
                if(timer <= 0) {
                    EnemyStatus = 2;
                    timer = time;
                }else {
                    timer -= Time.deltaTime;
                }
            }else if(EnemyStatus == 2) {
                ani.SetBool("isWalk", true);
                if(faceRight) {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    if(transform.position.x >= targetRightSide) {
                        ani.SetBool("isWalk", false);
                        transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
                        Flip();
                        EnemyStatus = 1;
                    }
            }else if(!faceRight) {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                if(transform.position.x <= targetLeftSide) {
                    ani.SetBool("isWalk", false);
                    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
                    Flip();
                    EnemyStatus = 1;
                }
                    }
                }
            }
        }

        if(flashcardused) {
            HP -= 15;
            flashcardused = false;
        }

        // HP
        if(HP <= 0) {
            AudioManager.PlaySound("dead");
            Destroy(this.gameObject);
            Instantiate(deadEffect, transform.position, transform.rotation);
        }
    }

    void Flip() {        
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player") {
            Player.health -= 10;
            Rigidbody2D palyerRB = other.collider.GetComponent<Rigidbody2D>();
            palyerRB.AddForce(Vector2.left * 4700f, ForceMode2D.Force);
        }
    }
}
