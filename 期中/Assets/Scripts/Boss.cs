using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject bossCollisionEffect;
    public GameObject bossDeadEffect;

    public float speed;
    public Transform playerPos;
    Rigidbody2D rb;
    public Text CountTime;

    float timeBTW = 4;
    int damage = 40;

    bool faceRight = false;

    public int HP = 1500;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Debug.Log(HP.ToString());
        if(timeBTW <= 0f) {
            // attact
            if(faceRight) {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
            }else if(!faceRight) {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
            }

            timeBTW = Random.Range(3f, 6f);
        }else {
            timeBTW -= Time.deltaTime;
        }


        // Display CountDown Time
        CountTime.text = Mathf.Round(timeBTW).ToString();

        // FLip
        if(playerPos.position.x > transform.position.x && faceRight == false) {
            Flip();
        }else if(playerPos.position.x < transform.position.x && faceRight == true) {
            Flip();
        }

        if(HP <= 0) {
            Destroy(gameObject);
            Instantiate(bossDeadEffect, transform.position, transform.rotation);
            AudioManager.PlaySound("bossDead");
            AudioManager.PlaySound("gameOver");
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            HP = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Instantiate(bossCollisionEffect, transform.position, transform.rotation);
        if(other.collider.tag == "Player") {
            Player.health -= damage;
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 5000f, ForceMode2D.Force);
        }
    }

    void Flip() {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
