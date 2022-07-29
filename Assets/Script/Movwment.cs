using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movwment : MonoBehaviour
{
    Rigidbody2D rig;
    SpriteRenderer cha;
    Animator anim;
    PlayerAttack attack;
    public Transform peluru;
    public GameObject[] hearth;
    public LayerMask layer;
    public Sprite[] herath;

    public int Kecepatan;
    float kebaldur;

    bool kebal;
    bool mati;
    int Lompatan;
    int darah;

    public float a { get; set; }

    void Start()
    {
        attack = GetComponent<PlayerAttack>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        cha = GetComponent<SpriteRenderer>();
        darah = 3;
        a = 3;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Lari", true);
        Lompat();

        if (kebaldur >= 1)
        {
            kebaldur -= Time.deltaTime;
            kebal = true;
        }
        else
        {
            anim.SetBool("Sakit", false);
            kebal = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            attack.Nembak(peluru);
        }

        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * Kecepatan, rig.velocity.y + Lompatan);
    }

    public void jalan()
    {
        if (rig.velocity.x > 0)
        {
            anim.SetBool("Lari", true);
            transform.localScale = new Vector3(.3f, .3f, .3f);
        }
        else if (rig.velocity.x < -0.01f)
        {
            anim.SetBool("Lari", true);
            transform.localScale = new Vector3(-.3f, .3f, .3f);
        }
        else
        {
            anim.SetBool("Lari", false);
        }
    }

    public void Lompat()
    {
        if (Input.GetKeyDown("space") && rig.velocity.y == 0) 
        {
            Lompatan = 8;
            anim.SetBool("Lompat", true);
        }
        else
        {
            Lompatan = 0;
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pijakan")
        {
            anim.SetBool("Lompat", false);
        }
    }

    public void Mati()
    {
        if (darah <= 0)
        {
            mati = true;
            anim.SetBool("Mati", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Darah")
        {
            GameManager.score += 1;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Duri")
        {
            kebaldur = 2;
            anim.SetBool("Sakit", true);

            GameManager.Mulai = false;
            cha.enabled = false;


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Musuh")
        {
            anim.SetBool("Sakit", true);
            GameManager.Mulai = false;
            cha.enabled = false;
        }
    }
}
