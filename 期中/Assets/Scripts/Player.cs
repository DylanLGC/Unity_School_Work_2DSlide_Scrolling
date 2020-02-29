using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource audio;
    public AudioClip jumpSound;
    public AudioClip shootingSound;

    public GameObject jumpEffect;

    public static int health;
    public float speed;
    float moveMent;
    public float jumpForce;
    public Rigidbody2D rb;
    public Animator ani;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject flashCardManage, healthCardManage, frezzeCardManage;
   
    bool faceRight;
    bool canJump;
    int jumpTime;
    

    void Start() {
        faceRight = true;
        jumpTime = 2;
        health = 100;

        audio = GetComponent<AudioSource>();
    }

    void Update() {
        moveMent = Input.GetAxis("Horizontal");
        
        // Jude is Player faceRight
        if(moveMent > 0 && !faceRight) {
            Flip();
        }
        else if(moveMent < 0 && faceRight) {
            Flip();
        }

        // Player Jump
        if(Input.GetKeyDown(KeyCode.Space) && canJump && jumpTime > 0) {
            Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y- 0.5f, transform.position.z), transform.rotation);
            
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            jumpTime--;
            audio.clip = jumpSound;
            audio.Play();
        }else if(jumpTime <= 0) {
            canJump = false;
        }

        // Card Manager
        if(Card.flashCard > 0) {
            flashCardManage.SetActive(true);
        }else {
            flashCardManage.SetActive(false);
        }

        if (Card.frezzeCard > 0) {
            frezzeCardManage.SetActive(true);
        }else {
            frezzeCardManage.SetActive(false);
        }

        if(Card.healthCard > 0) {
            healthCardManage.SetActive(true);
        }else {
            healthCardManage.SetActive(false);
        }


        // Player Move Ani
        if(moveMent != 0) {
            ani.SetBool("isRunning", true);
        }else{
            ani.SetBool("isRunning", false);
        }

        // Player Attact Ani and shotting
        if(Input.GetMouseButtonDown(0)) {
            ani.SetBool("isAttacting", true);
            Shoot();
        }
        else if(Input.GetMouseButtonUp(0)) {
            ani.SetBool("isAttacting", false);
        }


    }
    
    void FixedUpdate() {
        rb.velocity = new Vector2(moveMent * speed, rb.velocity.y);
    }

    void Flip() {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D other) {
        canJump = true;
        jumpTime = 2;
    }

    void Shoot() {
        // Judge Player's direction
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  
        audio.clip = shootingSound;
        audio.Play();
    }


}
