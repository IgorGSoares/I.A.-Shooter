using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class ShooterAgent : Agent
{
    public Vector3 startPos;
    GameObject gun;
    public GameObject origin;
    public GameObject prefab;
    public float intensity = 10f;

    public Transform Target;
    public GameObject clone;
    public int r;

    public override void Initialize()
    {
        //rBody = GetComponent<Rigidbody>();
        gun = this.gameObject;
        startPos = new Vector3(-10.07f, -12.85f, 0f);
        //gun.transform.position = new Vector3(10, 5, 0);
    }

    
    public override void OnEpisodeBegin()
    {
        //arma retorna para posição e angulos originais
        gun.transform.position = startPos; /*new Vector3(-10.07f, -12.85f, 0f);*/
        gun.transform.rotation = Quaternion.identity;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //acertos e erros

        //posição e angulo da arma
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(this.transform.rotation);

        //posição do spawner

        //posição do alvo
        sensor.AddObservation(Target.localPosition);
    }

    //public float forceMultiplier = 10;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        //ações = 3

        //mover random em z entre 7 e -7
        gun.transform.position = new Vector3(-10.07f, -12.85f, Random.Range(-10.0f, 10.0f));

        //mover random no angulo z entre 90 e -90
        gun.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f));

        //spawnar projétil
        r = Random.Range(0, 10);
        if(r == 0 || r == 9)
        {
            Debug.Log("entrou");
            clone = Instantiate(prefab, origin.transform.position, transform.rotation);
            //clone.transform.parent = gun.transform;
            clone.GetComponent<Rigidbody>().AddForce(transform.right * intensity, ForceMode.Impulse);
        }


        //recompensas e punições
        if(clone != null)
        {
            float distanceToTarget = Vector3.Distance(clone.transform.localPosition, Target.localPosition);

            if (distanceToTarget < 1.42f)
            {
                SetReward(1.0f);
                EndEpisode();
            }
        }

    }

    public void Shoot()
    {
        
    }
}
