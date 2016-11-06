﻿using UnityEngine;
using System.Collections;

public class PlayerHitDetection : MonoBehaviour {

    public KillEnemyDelegate killEnemy;
    PlayerControlScript controlScript;
    public SoundScript sounds;
    public Camera mainCam;
    Game game;

	// Use this for initialization
	void Start () {
        controlScript = GetComponentInParent<PlayerControlScript> ();
        sounds = mainCam.GetComponent<SoundScript> ();
        game = sounds.GetComponentInParent<Game> ();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "Bar") {
            if (controlScript.state == PlayerControlScript.PlayerStates.Dashing) {
                killEnemy (coll.gameObject);
                sounds.PlaySong(AudioToPlay.Destroy);
            } 
            else if(coll.tag == "Dogweed") {
                controlScript.state = PlayerControlScript.PlayerStates.DogWeed;
            } else {

                controlScript.state = PlayerControlScript.PlayerStates.Dying;
                if (game.lives <= 0) {
                    sounds.GameOver ();
                    return;
                }
                sounds.PlaySong (AudioToPlay.GameOver);
            }
        }
        if (coll.tag == "DeathCircle") {
            controlScript.state = PlayerControlScript.PlayerStates.Dying;
            sounds.PlaySong (AudioToPlay.GameOver);
        }
    }
}