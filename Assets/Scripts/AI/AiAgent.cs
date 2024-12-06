using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateId initialState;
    public AiAgentConfig config;

    [HideInInspector] public AiStateMachine stateMachine;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    //Ragdoll
    //SkinnedMeshRenderer
    //UIHealthBar
    /*[HideInInspector]*/ public Transform playerTransform;
    [HideInInspector] public AiSensor sensor;
    [HideInInspector] public AiTargetingSystem targeting;
    //AiHealth

    void Start()
    {
        //ragdoll
        //mesh
        //ui
        navMeshAgent = GetComponent<NavMeshAgent>();
        sensor = GetComponent<AiSensor>();
        targeting = GetComponent<AiTargetingSystem>();
        //health

        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiWalkState());
        stateMachine.RegisterState(new AiFindPlayerState());
        stateMachine.RegisterState(new AiChaseState());
        stateMachine.RegisterState(new AiAttackState());
        stateMachine.ChangeState(initialState);
    }

    void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(AiStateId newState)
    {
        stateMachine.ChangeState(newState);
    }
}
