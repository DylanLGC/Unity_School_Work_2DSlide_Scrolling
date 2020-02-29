using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public int fireDamage;

    void OnCollisionEnter2D(Collision2D other) {
        
        
        if(other.collider.tag == "Player") {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.left * 4700f, ForceMode2D.Force);
            Player.health -= fireDamage;
        }
    }
}
