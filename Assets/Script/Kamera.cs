using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public float jarak;
    public float speed;

    public Transform player;
    Vector3 tujuan;

    private void Start()
    {

    }

    void Update()
    {
        tujuan = new Vector3(player.position.x + (jarak * player.localScale.x), player.position.y + jarak-2, -10);

        transform.position = Vector3.Lerp(transform.position, tujuan, speed);
    }
}
