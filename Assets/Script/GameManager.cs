using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform duri, coin;
    public Transform[] Awal,musuh;
    public static Vector3 posplay;
    public Transform player;
    public float waktu;
    float wakktu;

    public GameObject GameOver;
    
    public static int score;

    public Text Tscore;

    public static bool Mulai;

    private void Start()
    {
        wakktu = waktu;
        posplay = player.position;
        Mulai = true;
        score = 0;
    }

    private void Update()
    {
        if (Mulai)
        {
            posplay = player.position;
            wakktu -= Time.deltaTime;

            Tscore.text = score.ToString();

            if (wakktu <= 0)
            {
                int ran = Random.Range(0, Awal.Length);
                int sp = Random.Range(0, 2);
                int coin = Random.Range(0, 2);
                int jen = Random.Range(0, 2);

                Instantiate(duri, Awal[ran].position, Awal[ran].rotation);

                if (sp == 1)
                {
                    Instantiate(musuh[jen], Awal[ran].position, Awal[ran].rotation);
                }
                if (coin == 1)
                {
                    Instantiate(this.coin, Awal[sp].position, Awal[sp].rotation);
                }

                wakktu = waktu;
            }
        }
        else
        {
            GameOver.SetActive(true);
        }
        
    }

    public void restart(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
