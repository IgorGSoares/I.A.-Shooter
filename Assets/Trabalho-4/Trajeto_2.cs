using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajeto_2 : MonoBehaviour
{
    public float speed = 2;
    public bool colidiu = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Alvo")
        {
            colidiu = true;
        }
    }
}
