using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int Scenes;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            SceneManager.LoadScene(Scenes);
            Card.flashCard = 0;
            Card.frezzeCard = 0;
            Card.healthCard = 0;
        }
    }
}
