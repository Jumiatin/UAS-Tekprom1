using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obst : MonoBehaviour
{
    Transform obs;

    public Transform Awal;

    public float speed;
    public bool tanah, Bg, musuh;



    void FixedUpdate()
    {
        transform.position += transform.right * -speed;

        if (musuh)
        {
            transform.position = new Vector3(transform.position.x, GameManager.posplay.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tanah || Bg)
        {
            if (collision.gameObject.tag == "Reset")
            {
                transform.position = Awal.position;
            }
        }
        else if (collision.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }
}
