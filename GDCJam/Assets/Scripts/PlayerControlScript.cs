﻿using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{
    public float speed = 0.08f;
    public float dashSpeed = 0.1f;
    public float elapsedTime = 0.4f;
    private float time;

    public enum PlayerStates
    {
        Normal,
        Dashing,
        Dying,
        Dead,
        PowerUp
    };

    public PlayerStates state = PlayerStates.Normal;

    // Use this for initialization
    void Start()
    {
        time = Time.time;
        Debug.Log ("Start");
    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "Bar") {
            Destroy (coll.gameObject.transform.parent.gameObject);
            Debug.Log ("Delete item");
        }
    }

// Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        float translation = Time.deltaTime*10;

        Vector3 movement = new Vector3(inputX, inputY, 0);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation (Vector3.forward, movement);
        }

        transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, speed);

        if (Time.time <= time + elapsedTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + movement, dashSpeed);
        }
        else if (state == PlayerStates.Dashing)
        {
            state = PlayerStates.Normal;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            time = Time.time;
            state = PlayerStates.Dashing;
        }
        
        Debug.Log(state.ToString());
    }
}