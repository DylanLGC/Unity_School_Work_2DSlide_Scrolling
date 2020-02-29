using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player") {
            Player.health = 0;
        }else if(other.collider.tag == "Slime") {
            other.collider.GetComponent<Slime>().HP = 0;
        }else if(other.collider.tag == "Enemy01") {
            other.collider.GetComponent<Enemy01>().HP = 0;
        }
    }
}
