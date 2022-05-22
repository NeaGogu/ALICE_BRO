using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    public TextMeshProUGUI tmp;
    public fade f;
    public spawner spawn;
    private Vector2 movement;
    private Rigidbody2D rbody;
    private float timer;
    private float glitchTimer = 0;
    private int time;
    private bool glitch = false;

    public GameObject walls;
    public bool hitPower;
    public float powerupTimer;


    public bool aliceInvic;
    
    
    private void Awake()
    {
        // Hello
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        tmp.text = time.ToString();
        timer += Time.deltaTime;
        powerupTimer -= Time.deltaTime;
        glitchTimer += Time.deltaTime;
        if (timer >= 1f) {
            time += 1;
            timer = 0;
        }
        
        // Power up timer (countdown)
        if (powerupTimer <= 0)
        {
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            hitPower = false;
        }
        
        if (aliceInvic)
        {
            if (powerupTimer <= 0)
            {
                aliceInvic = false;
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        
        if ( time == 20) {
            f.run();
            spawn.timer = 10;
            time = 0;
            glitch = true;
            glitchTimer = 0;
        }
        if (glitch && glitchTimer >= 0.3f) {
            time *= 2;
            glitchTimer = 0;
        }
        Movement();
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void Movement()
    {
        Vector2 currentPos = rbody.position;

        Vector2 adjustedMovement = movement * movementSpeed;

        Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;

        rbody.MovePosition(newPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            if (aliceInvic)
            {
                Destroy(collision.gameObject);
                return;
            }
            SceneManager.LoadScene("scene1");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // ADD VISUAL INDICATOR
        if (col.gameObject.CompareTag("stopWall"))
        {
            // Stop the walls power up (and push them back)
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            hitPower = true;
            powerupTimer = 2;
            Destroy(col.gameObject);
        }
        // ADD VISUAL INDICATOR
        if (col.gameObject.CompareTag("powerup"))
        {
            // The invicibility powerup (Alice becomes god)
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log(gameObject.transform.GetChild(0).gameObject);
            aliceInvic = true;
            powerupTimer = 2;
            Destroy(col.gameObject);
        }
    }
}
