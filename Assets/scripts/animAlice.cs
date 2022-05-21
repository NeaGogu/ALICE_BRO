using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animAlice : MonoBehaviour
{
    public SpriteRenderer alice;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= .2 && alice.flipY) {
            alice.flipY = false;
        }
        if (timer >= .2 && !alice.flipY)
        {
            alice.flipY = true;
        }
    }
}
