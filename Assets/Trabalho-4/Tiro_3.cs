using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Tiro_3 : Agent
{
    Rigidbody rBody;
    public Transform Target;
    public float forceMultiplier = 10;
    public GameObject origin;
    public GameObject prefab;
    public GameObject clone;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        this.rBody.angularVelocity = Vector3.zero;
        this.rBody.velocity = Vector3.zero;
        this.transform.localPosition = new Vector3(Random.Range(-6.0f, 6.0f), -4.79f, -6.64f);
        //Target.localPosition = new Vector3(Random.Range(-7.0f, 7.0f), -4.79f, 7.04f);
    }


    public override void OnEpisodeBegin()
    {
        //reseta se sair do cenário
        if (this.transform.localPosition.x <= -7.30f || this.transform.localPosition.x >= 7.30f)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3(Random.Range(-7.0f, 7.0f), -4.79f, -6.64f);
            //Target.localPosition = new Vector3(Random.Range(-7.0f, 7.0f), -4.79f, 7.04f);
        }
        Target.localPosition = new Vector3(Random.Range(-6.0f, 6.0f), -4.79f, 7.04f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        // Agent velocity
        sensor.AddObservation(rBody.velocity.x);
        //sensor.AddObservation(rBody.velocity.z);
    }


    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 1
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        rBody.AddForce(controlSignal * forceMultiplier);

        //Invoke("Shoot", 3);

        //StartCoroutine(Timeout());

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);
        //Debug.Log(distanceToTarget);

        // Reached target
        if (distanceToTarget >= 13.68f && distanceToTarget <= 13.73f)
        {
            if(clone == null)
            {
                clone = Instantiate(prefab, origin.transform.position, transform.rotation);
            }
            SetReward(1.0f);
            //EndEpisode();
        }

        //fora da area
        if (this.transform.localPosition.x <= -7.30f || this.transform.localPosition.x >= 7.30f)
        {
            SetReward(-0.5f);
            EndEpisode();
        }


        //tiro acertou alvo
        if (clone != null)
        {
            //float d = Vector3.Distance(clone.transform.localPosition, Target.localPosition);
            //Debug.Log(d);
            if (clone.GetComponent<Trajeto_2>().colidiu == true)
            {
                Destroy(clone);
                SetReward(0.5f);
                EndEpisode();
            }
        }


    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        //Debug.Log("entrou");
    }

    public void entrar()
    {
        Debug.Log("entrou no metodo entrar");
    }

    //public void GiveReward()
    //{
    //    Debug.Log("entrou give reward");
    //    SetReward(0.5f);
    //    EndEpisode();
    //}

    //public void GivePenality()
    //{
    //    SetReward(-0.5f);
    //    EndEpisode();
    //}

    //public void Finalizar()
    //{
    //    EndEpisode();
    //}

    //public void SpawnBall()
    //{
    //    clone = Instantiate(prefab, origin.transform.position, transform.rotation);
    //}
}
