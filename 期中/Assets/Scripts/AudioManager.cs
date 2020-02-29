using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip deadSound, bossDeadSound, gameOverSound, pickupCard;
    static AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
        gameOverSound = Resources.Load<AudioClip>("gameOver");
        deadSound = Resources.Load<AudioClip>("dead");
        bossDeadSound = Resources.Load<AudioClip>("bossDead");
        pickupCard = Resources.Load<AudioClip>("Pickup");
        
    }

    public static void PlaySound(string clip) {
        switch(clip) {
            case "dead":
                audio.PlayOneShot(deadSound);
                break;
            case "bossDead":
                audio.PlayOneShot(bossDeadSound);
                break;
            case "gameOver":
                audio.PlayOneShot(gameOverSound);
                break;
            case "pick":
                audio.PlayOneShot(pickupCard);
                break;
        }
    }
}
