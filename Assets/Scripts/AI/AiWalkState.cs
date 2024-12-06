using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWalkState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Walk;
    }
    public void Enter(AiAgent agent)
    {
        Debug.Log("Enter WalkState");
        //определяем первую точку маршрута
        agent.navMeshAgent.speed = agent.config.walkSpeed;
    }

    public void Update(AiAgent agent)
    {
        //Debug.Log("Update WalkState");
        //проверить, что игра не на паузе и игрок жив
        
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        if (playerDirection.magnitude > agent.config.distanceListening)
        {
            agent.stateMachine.ChangeState(AiStateId.Idle);
        }
        else if (playerDirection.magnitude < agent.config.distanceVision)
        {
            Vector3 agentDirection = agent.transform.forward;
            playerDirection.Normalize();

            float dotProdact = Vector3.Dot(playerDirection, agentDirection);
            if (dotProdact > 0.0f)
            {
                agent.stateMachine.ChangeState(AiStateId.Chase);
            }
        }
    }

    public void Exit(AiAgent agent)
    {
        Debug.Log("Exit WalkState");
    }
}
