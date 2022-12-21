using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    public UnityEvent<Vector3> OnPositioSet = new UnityEvent<Vector3>();

    [SerializeField]
    private Transform scope;
    [SerializeField]
    private LayerMask groundMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetPosition();
        }
    }

    public void GetPosition()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, groundMask);

        scope.position = hit.point;

        OnPositioSet?.Invoke(hit.point);
    }
}
