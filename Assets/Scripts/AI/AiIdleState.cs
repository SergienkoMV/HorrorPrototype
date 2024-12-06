using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }
    public void Enter(AiAgent agent)
    {
        Debug.Log("Enter IdleState");
        agent.navMeshAgent.ResetPath();
    }

    public void Update(AiAgent agent)
    {
        //проверить, что игра не на паузе и игрок жив
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        Debug.Log(playerDirection.magnitude);
        if (playerDirection.magnitude < agent.config.distanceListening)
        {
            //вероятно стоит получить направление, но возможно это нужно сделать в начале следующего метода
            agent.navMeshAgent.destination = agent.playerTransform.position;
            agent.stateMachine.ChangeState(AiStateId.Walk);
        }

        //Debug.Log("Update IdleState");
    }

    public void Exit(AiAgent agent)
    {
        Debug.Log("Exit IdleState");
    }
}
