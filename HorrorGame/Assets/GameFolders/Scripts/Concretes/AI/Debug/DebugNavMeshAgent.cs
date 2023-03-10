using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugNavMeshAgent : MonoBehaviour
{
    public bool Velocity;
    public bool DesiredVelocity;
    public bool Path;

    [SerializeField] EnemyAI _ai;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _transform;

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(transform.position, _ai.Radius);

        if(Velocity)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_transform.position, _transform.position + _agent.velocity);
        }
        if(DesiredVelocity)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_transform.position, _transform.position + _agent.desiredVelocity);
        }
        if(Path)
        {
            Gizmos.color = Color.black;
            Vector3 prevCorner = _transform.position;
            var agentPath = _agent.path;
            foreach(var corner in agentPath.corners)
            {
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);
                prevCorner = corner;
            }
            
        }
    }

}
