using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Unit
{
    private Raycaster raycaster;

    public void SetTargetPosition(Vector3 position)
    {
        MeshAgent.SetDestination(position);
    }

    public void SetRaycaster(Raycaster raycaster)
    {
        this.raycaster = raycaster;
        raycaster.OnPositioSet.RemoveListener(SetTargetPosition);
        raycaster.OnPositioSet.AddListener(SetTargetPosition);
    }

    void Update()
    {
        InstantlyTurn(MeshAgent.destination);
    }

    private void InstantlyTurn(Vector3 destination)
    {
        //When on target -> dont rotate!
        if ((destination - transform.position).magnitude < 1f) return;
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * 360);
    }
}