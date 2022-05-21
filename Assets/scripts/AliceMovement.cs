using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AliceMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private Vector2 movement;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    
    private void FixedUpdate()
    {
        // Reset moveDelta
        float x = movement.x;
        float y = movement.y;
        moveDelta = new Vector3(x, y, 0);

        // swap sprite direction 
        if (moveDelta.x < 0) {
            transform.localScale = Vector3.one;
        } else if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // make sure we can move in this direction by casting a box there first
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0,
            new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null) {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }	
    }
}
