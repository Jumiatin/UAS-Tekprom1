using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject ledakan;
    int arah;
    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        if (transform.parent.transform.localScale.x > 0)
        {
            arah = 1;           
        }
        else
        {
            arah = -1;
        }
        transform.parent = null;
        transform.localScale = new Vector3(arah, 1, 1);
        speed = speed * arah;
    }

    // Update is called once per frame
    void Update()
    {
        jalan();
    }

    public void jalan()
    {
        rig.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(ledakan, transform.position, ledakan.transform.rotation);
        Destroy(this.gameObject);

        if (collision.gameObject.tag == "Musuh")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
