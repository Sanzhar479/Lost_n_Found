using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness_Effect : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public Collider2D player;
    void Start()
    {
        for (int i = 0; i < sprites.Length; i++)
            sprites[i].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    { for (int i = 0; i < sprites.Length; i++)
        {
            if (collision == player)
                sprites[i].enabled = true;
            else sprites[i].enabled = false;
        }
    }
}
