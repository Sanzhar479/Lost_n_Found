using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness_Effect : MonoBehaviour
{
    private bool invisible = false;
    // Start is called before the first frame update
    void Start()
    {
        invisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (invisible == true)
        {   
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        invisible = true;
    }
}
