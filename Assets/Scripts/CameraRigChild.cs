using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct CameraRigChild : IComponentData
{
    public Entity Value;
    public float3 headPose;
    public quaternion headRot;
    public float3 leftHandPose;
    public quaternion leftHandRot;
    public float3 rightHandPose;
    public quaternion rightHandRot;
    [System.Serializable]
    public struct Transform
    {
        public float3 positon;
        public quaternion rotation;
    }
}
