using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audio;
    public Text playerHealth;
    GameObject BOSS;

    float gameOverTime = 6f;

    void Start() {
        audio.Play();
        BOSS = GameObject.FindGameObjectWithTag("Boss");
    }

    void Update() {
        playerHealth.text = "HP : " + Player.health.ToString();
        
        if(Player.health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Card.healthCard = 0;
            Card.flashCard = 0;
            Card.frezzeCard = 0;
        }

        if(Input.GetKeyDown(KeyCode.F1)) {
            SceneManager.LoadScene(1);
            Card.healthCard = 0;
            Card.flashCard = 0;
            Card.frezzeCard = 0;
        }else if(Input.GetKeyDown(KeyCode.F2)) {
            SceneManager.LoadScene(2);
            Card.healthCard = 0;
            Card.flashCard = 0;
            Card.frezzeCard = 0;
        }else if(Input.GetKeyDown(KeyCode.F3)) {
            SceneManager.LoadScene(3);
            Card.healthCard = 0;
            Card.flashCard = 0;
            Card.frezzeCard = 0;
        }else if(Input.GetKeyDown(KeyCode.F4)) {
            SceneManager.LoadScene(4);
            Card.healthCard = 0;
            Card.flashCard = 0;
            Card.frezzeCard = 0;
        }else if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
            Card.healthCard = 0;
            Card.flashCard = 0;
            Card.frezzeCard = 0;
        }

        if(BOSS != null) {
            BossScene();
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        Card.healthCard = 0;
        Card.flashCard = 0;
        Card.frezzeCard = 0;

        Card.healthCardUsed = false;
        Card.flashCardUsed = false;
        if(other.collider.tag == "Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void ButtonLoadScene(int index) {
        Card.healthCard = 0;
        Card.flashCard = 0;
        Card.frezzeCard = 0;

        SceneManager.LoadScene(index);
    }

    public void QUIT() {
        Application.Quit();
    }

    void BossScene() {
        if(BOSS.GetComponent<Boss>().HP <= 0) {
            audio.Stop();
        }
    }
}
