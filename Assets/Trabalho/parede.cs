using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parede : MonoBehaviour
{
    public GameObject gun;
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("entrou parede");
            Destroy(collision.gameObject);
            gun.GetComponent<ShooterAgent>().EndEpisode();
        }
    }
}
