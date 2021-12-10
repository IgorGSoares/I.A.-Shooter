using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Tiro_2 : Agent
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
        this.transform.localPosition = new Vector3(Random.Range(-7.0f, 7.0f), -4.79f, -6.64f);
    }


    public override void OnEpisodeBegin()
    {
        //reseta se sair do cenário
        if (this.transform.localPosition.x <= -7.30f || this.transform.localPosition.x >= 7.30f)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3(Random.Range(-7.0f, 7.0f), -4.79f, -6.64f);
        }
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
        Debug.Log(distanceToTarget);

        // Reached target
        if (distanceToTarget >= 13.68f && distanceToTarget <= 13.73f)
        {
            clone = Instantiate(prefab, origin.transform.position, transform.rotation);
            SetReward(1.0f);
            EndEpisode();
        }

        //fora da area
        if (this.transform.localPosition.x <= -7.30f || this.transform.localPosition.x >= 7.30f)
        {
            SetReward(-1.0f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        //Debug.Log("entrou");
    }
}
