using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChaseState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Chase;
    }

    public void Enter(AiAgent agent)
    {
        Debug.Log("Enter ChaseState");
        //устанавливаем скорость преследования
        agent.navMeshAgent.speed = agent.config.chaseSpeed;
        
    }

    public void Update(AiAgent agent)
    {
        //Debug.Log("Update ChaseState");
        //проверить, что игра не на паузе и игрок жив
        agent.navMeshAgent.destination = agent.playerTransform.position;
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        //Debug.Log(playerDirection.magnitude);
        if (playerDirection.magnitude < agent.config.distanceListening && playerDirection.magnitude > agent.config.distanceVision)
        {
            //вероятно стоит получить направление, но возможно это нужно сделать в начале следующего метода
            agent.navMeshAgent.destination = agent.playerTransform.position;
            agent.stateMachine.ChangeState(AiStateId.Walk);
        }
    }

    public void Exit(AiAgent agent)
    {
        Debug.Log("Exit ChaseState");
    }
}
