using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPre : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            AudioManager.PlaySound("pick");
            Destroy(gameObject);

            if(gameObject.tag == "FlashCardPre") {
                Card.flashCard += 1;
            }else if (gameObject.tag == "HealthCardPre") {
                Card.healthCard += 1;
            }else if(gameObject.tag == "FrezzeCardPre") {
                Card.frezzeCard += 1;
            }
        }
    }   
}
