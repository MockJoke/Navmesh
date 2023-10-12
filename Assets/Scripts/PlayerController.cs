using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;

    void Awake()
    {
        if (cam == null)
            cam = FindObjectOfType<Camera>();

        if (agent == null)
            agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Input.mousePosition -> curr pos of mouse in screen co-ord, ScreenPointToRay -> converts this curr mouse pos on the screen
            // to into a ray that we can shoot out
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            // Used to store info about what the ray hits
            RaycastHit hit;
            
            // Raycast -> to shoot the ray
            if (Physics.Raycast(ray, out hit))
            {
                // Move our agent
                agent.SetDestination(hit.point);
            }
        }
    }
}
