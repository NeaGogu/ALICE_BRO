using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class animAlice : MonoBehaviour
{
    public SpriteRenderer alice;
    float timer;
    public Sprite falling1, falling2, falling3;
    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, 0.5f);
    }

    private void Update()
    {
    }

    private void SlowUpdate()
    {
        int num = Random.Range(1, 3);
        switch (num)
        {
            case 1:
                alice.sprite = falling1;
                return;
            case 2:
                alice.sprite = falling2;
                return;
            case 3:
                alice.sprite = falling3;
                return;
        }
        
    }
}
