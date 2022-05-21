using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls : MonoBehaviour
{
    public int speed = 10;
    public GameObject wall;
    public GameObject spawnpointMain;
    private GameObject oldwalls;
    private GameObject newWall;

    public float direction = 1;
    public playerController pc;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pc.hitPower)
        {
            direction = -1;
            
        }
        else
        {
            direction = 1;
        }
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destroy") && newWall == null)
        {
            if (oldwalls != null)
            {
                Destroy(oldwalls);
            }
            newWall = Instantiate(wall, transform.position + new Vector3(0, -12, 0), transform.rotation);
            newWall.GetComponent<walls>().oldwalls = gameObject;
            newWall.transform.localScale += new Vector3 (-0.01f * direction, 0, 0);
            spawnpointMain.transform.localScale += new Vector3(-0.01f, 0, 0);
        }
    }
}
