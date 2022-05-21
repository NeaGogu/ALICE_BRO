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
    private Vector2 movement;
    private Rigidbody2D rbody;
    private float timer;
    private int time;

    public GameObject walls;
    public bool hitPower;
    public float powerupTimer;

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
        if (timer >= .8f) {
            time += 1;
            timer = 0;
        }

        if (powerupTimer <= 0)
        {
            hitPower = false;
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
            SceneManager.LoadScene("scene1");
        }

        if (collision.gameObject.CompareTag("stopWall"))
        {
            // Get Power up
            hitPower = true;
            powerupTimer = 2;

        }
    }
}
