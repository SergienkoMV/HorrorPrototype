using UnityEngine;

[CreateAssetMenu(fileName = "SaveSettingsSriptable", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SaveSettingsSriptable : ScriptableObject
{
    public float MoveSpeed;
    public float RunSpeed;
    public float RotationSpeed;
    public float JumpForce;
    public float JumpTorque;
    public float SunLightForce;
    public float LightFlashlight;
    public float WidthLightFlashlight;
    public float RangeLightFlashlight;
    public float FogDensity;
}
