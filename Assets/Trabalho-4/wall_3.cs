using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_3 : MonoBehaviour
{
    //public bool isTarget = false;
    //public GameObject gun;
    void Start()
    {
        //gun = GameObject.Find("Player");
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
            //    Debug.Log("entrou if istarget true");
            //    gun.GetComponent<Tiro_3>().entrar();
            //    //gun.GetComponent<Tiro_3>().GiveReward();
            //    //gameObject.transform.localPosition = new Vector3(Random.Range(-7.0f, 7.0f), -4.79f, 7.04f);
            //}
            //else
            //    gun.GetComponent<Tiro_3>().Finalizar();
        }
    }
}
