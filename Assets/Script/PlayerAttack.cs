using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public void Nembak(Transform Peluru)
    {
        Instantiate(Peluru, transform);
    }
    
}
