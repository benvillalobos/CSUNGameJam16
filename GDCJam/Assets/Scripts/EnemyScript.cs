﻿using UnityEngine;
using System.Collections;

public enum EnemyType
{
    Basic,
    FourArm
}
public class EnemyScript : MonoBehaviour {

    public GameObject Player;
    public float speed = 0.06f;
    public int arms = 0;
    public int rotateDirection = 1;
    public  int score = 100;
	// Use this for initialization
    void Start () {
        //count how many arms an enemy has
        foreach (Transform child in transform) {
            if (child.tag == "Bar") {
                arms++;
            }
        }
        rotateDirection = UnityEngine.Random.Range (1, 2) == 2 ? -1 : 1;
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, speed);
        transform.Rotate (Vector3.forward * rotateDirection);

        if (arms <= 0) {
            Destroy (gameObject);
        }
	}
}
