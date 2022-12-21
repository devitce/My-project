using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent meshAgent;
    public NavMeshAgent MeshAgent => meshAgent;

    // Update is called once per frame
    void Update()
    {
        
    }
}
