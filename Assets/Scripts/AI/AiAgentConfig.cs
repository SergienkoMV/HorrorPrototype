using UnityEngine;

[CreateAssetMenu]
public class AiAgentConfig : ScriptableObject
{
    public float distanceListening;
    public float distanceVision;
    public float walkSpeed;
    public float chaseSpeed;
}
