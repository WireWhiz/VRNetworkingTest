using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.SpatialTracking;

[GenerateAuthoringComponent]
public struct CameraRigData : IComponentData
{
    public Entity root;
    public Entity head;
    public Entity leftHand;
    public Entity rightHand;
}
public static class CameraRigEntity
{
    public static Entity Value;
    public static World World;
}