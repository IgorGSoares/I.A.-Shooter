using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alvo : MonoBehaviour
{
    public GameObject gun;
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("entrou alvo");
            Destroy(collision.gameObject);
            gun.GetComponent<ShooterAgent>().SetReward(1.0f);
            gun.GetComponent<ShooterAgent>().EndEpisode();
        }
    }
}
