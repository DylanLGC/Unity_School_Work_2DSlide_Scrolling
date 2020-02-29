using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject shootingEffect;
    public float speed;
    Rigidbody2D rb;
    float despearTime;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        despearTime = 1f; //0.25
    }

    void Update() {
        if(despearTime <= 0) {
            Destroy(gameObject);
        }else {
            despearTime -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Instantiate(shootingEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        if(other.tag == "Enemy01") {
            other.GetComponent<Enemy01>().HP -= 10;
        }else if(other.tag == "Slime") {
            other.GetComponent<Slime>().HP -= 10;
        }else if(other.tag == "Boss") {
            other.GetComponent<Boss>().HP -= 10;
        }
    }

}
