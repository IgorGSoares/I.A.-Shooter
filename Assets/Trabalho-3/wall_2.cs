using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_2 : MonoBehaviour
{
    public bool isTarget = false;
    public GameObject gun;
    void Start()
    {
        gun = GameObject.Find("Player");
        //Debug.Log(this.transform.name + ", " + isTarget);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("entrou");

        if (collision.gameObject.tag == "Bullet")
        {
            //Debug.Log("nome: " + collision.gameObject.name + ", tag : " + collision.gameObject.tag);
            Destroy(collision.gameObject);
            //if (isTarget == true)
            //{
            //    gun.GetComponent<Tiro>().GiveReward();
            //}
            //else
            //    gun.GetComponent<Tiro>().Finalizar();
        }
    }
}
