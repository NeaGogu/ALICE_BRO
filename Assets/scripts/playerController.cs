using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

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

    private void Awake()
    {
        // Hello
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        tmp.text = time.ToString();
        timer += Time.deltaTime;
        glitchTimer += Time.deltaTime;
        if (timer >= 1f) {
            time += 1;
            timer = 0;
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
            SceneManager.LoadScene("scene1");
        }
    }
}
