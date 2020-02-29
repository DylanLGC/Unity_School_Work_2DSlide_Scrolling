using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int flashDamage = 15;

    public GameObject playerHealthCardEffect;

    public GameObject healthParticleEffect;
    public GameObject frezzeParticleEffect;
    public GameObject flashParticleEffect;

    public Transform CameraPos;
    public Vector2 currentPos;
    public Vector2 targetPos;
    
    public float currentOffsetX;
    public float targetOffsetX;

    public Vector2 currentScale;
    public Vector2 targetScale;

    Vector2 mousePos;

    bool selected;

    // Totals Cards On Map
    public static int flashCard = 0; 
    public static int healthCard = 0;
    public static int frezzeCard = 0;

    float healthTimer = 30f;
    public static bool healthCardUsed;

    public static bool flashCardUsed;
    

    void Update() {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(selected) {
            transform.position = mousePos;
        }

        // health Card Magic
        if(healthCardUsed) {
            if(healthTimer <= 0f) {
                Player.health = 100;
                playerHealthCardEffect.SetActive(false);
                healthTimer = 0f;
                healthCardUsed = false;
            }
            healthTimer -= Time.deltaTime;
        }


    }

    void FixedUpdate() {
        currentPos.x = CameraPos.position.x + currentOffsetX;
        targetPos.x = CameraPos.position.x + targetOffsetX;
    } 

    void OnMouseOver() {
        transform.position = targetPos;
        transform.localScale = targetScale;
    }

    void OnMouseDrag() {
        selected = true;
    }

    void OnMouseUp() {
        selected = false;
        
        if(transform.position.y > -1f) {
            //Destroy(gameObject);
            
            // Card 
            if(gameObject.tag == "health card") {
                healthCard -= 1;
                // Health
                Player.health = 150;
                Instantiate(healthParticleEffect, transform.position, transform.rotation);
                healthCardUsed = true;
                playerHealthCardEffect.SetActive(true);
                
            }else if(gameObject.tag == "frezz card") {
                frezzeCard -= 1;
                // Frezze
                Instantiate(frezzeParticleEffect, transform.position, transform.rotation);
                Enemy01.frezze = true;
                Slime.frezze = true;
            }else if(gameObject.tag == "flash card") {
                flashCard -= 1;
                // flash
                Instantiate(flashParticleEffect, transform.position, transform.rotation);
                Slime.flashcardused = true;
                Enemy01.flashcardused = true;
            }
        }
    }

    void OnMouseExit() {
        transform.position = currentPos;
        transform.localScale = currentScale;
        selected = false;
    }
    
}
