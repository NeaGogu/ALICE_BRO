using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    public int speed = 15;
    public GameObject background;
    public GameObject oldBG;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destroy"))
        {
            if (oldBG != null) {
                Destroy(oldBG);
            }
            GameObject backg = Instantiate(background, transform.position + new Vector3(0, -17.2f, 0), transform.rotation);
            backg.GetComponent<bg>().oldBG = gameObject;
        }
    }
}
