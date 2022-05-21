using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animAlice : MonoBehaviour
{
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= .3 && transform.rotation.y == 180) {
            Quaternion angle = transform.rotation;
            angle.eulerAngles += new Vector3(0, -180,0 );
            transform.rotation = angle;
            timer = 0;
        }
        if (timer >= .3 && transform.rotation.y != 180)
        {
            Quaternion angle = transform.rotation;
            angle.eulerAngles += new Vector3(0, 180, 0);
            transform.rotation = angle;
            timer = 0;
        }
    }
}
