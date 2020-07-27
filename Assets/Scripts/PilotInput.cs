using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Networking.Transport;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.SpatialTracking;

public struct PilotInput : ICommandData<PilotInput>
{
    public uint Tick => tick;
    public uint tick;
    
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    [System.Serializable]
    public struct Transform
    {
        public float3 positon;
        public quaternion rotation;
        public void Deserialize(ref DataStreamReader reader)
        {
            positon.x = reader.ReadFloat();
            positon.y = reader.ReadFloat();
            positon.z = reader.ReadFloat();
            rotation.value.x = reader.ReadFloat();
            rotation.value.y = reader.ReadFloat();
            rotation.value.z = reader.ReadFloat();
            rotation.value.w = reader.ReadFloat();
        }
        public void Serialize(ref DataStreamWriter writer)
        {
            writer.WriteFloat(positon.x);
            writer.WriteFloat(positon.y);
            writer.WriteFloat(positon.z);
            writer.WriteFloat(rotation.value.x);
            writer.WriteFloat(rotation.value.y);
            writer.WriteFloat(rotation.value.z);
            writer.WriteFloat(rotation.value.w);
        }
    }
    
    public void Deserialize(uint tick, ref DataStreamReader reader)
    {
        this.tick = tick;
        head.Deserialize(ref reader);
        leftHand.Deserialize(ref reader);
        rightHand.Deserialize(ref reader);
    } 
    public void Serialize(ref DataStreamWriter writer)
    {
        head.Serialize(ref writer);
        leftHand.Serialize(ref writer);
        rightHand.Serialize(ref writer);
    }

    public void Deserialize(uint tick, ref DataStreamReader reader, PilotInput baseline, NetworkCompressionModel compressionModel)
    {
        Deserialize(tick, ref reader);
    }

    
    public void Serialize(ref DataStreamWriter writer, PilotInput baseline, NetworkCompressionModel compressionModel)
    {
        Serialize(ref writer);
    }
}

public class PilotSendCommandSystem : CommandSendSystem<PilotInput>
{
}

public class PilotReceiveCommandSystem : CommandReceiveSystem<PilotInput>
{
}

[UpdateInGroup(typeof(ClientSimulationSystemGroup))]
public class PilotInputNetowrking : SystemBase
{
    protected override void OnCreate()
    {
        RequireSingletonForUpdate<NetworkIdComponent>();
        RequireSingletonForUpdate<EnablePlayersGhostReceiveSystemComponent>();
    }
    protected override void OnUpdate()
    {
        var localInput = GetSingleton<CommandTargetComponent>().targetEntity;
        var entityManager = EntityManager;
        if (localInput == Entity.Null)
        {
            var localPlayerId = GetSingleton<NetworkIdComponent>().Value;
            Entities.WithStructuralChanges().WithNone<PilotInput>().ForEach((Entity ent, ref PilotData pilot ) =>
            {
                if (pilot.PlayerId == localPlayerId)
                {
                    UnityEngine.Debug.Log("Adding input buffer");
                    pilot.clientHasAuthority = true;
                    entityManager.AddBuffer<PilotInput>(ent);
                    entityManager.SetComponentData(GetSingletonEntity<CommandTargetComponent>(), new CommandTargetComponent { targetEntity = ent });
                }
            }).Run();
            
            return;
        }
        //Debug.Log("updateing input");
        var input = default(PilotInput);
        input.tick = World.GetExistingSystem<ClientSimulationSystemGroup>().ServerTick;
        PoseDataSource.GetDataFromSource(TrackedPoseDriver.TrackedPose.Center, out Pose head);
        PoseDataSource.GetDataFromSource(TrackedPoseDriver.TrackedPose.LeftPose, out Pose leftHand);
        PoseDataSource.GetDataFromSource(TrackedPoseDriver.TrackedPose.RightPose, out Pose rightHand);
        
        input.head = new PilotInput.Transform
        {
            positon = head.position,
            rotation = head.rotation
        };
        input.leftHand = new PilotInput.Transform
        {
            positon = leftHand.position,
            rotation = leftHand.rotation
        };
        input.rightHand = new PilotInput.Transform
        {
            positon = rightHand.position,
            rotation = rightHand.rotation
        };
        
        var inputBuffer = EntityManager.GetBuffer<PilotInput>(localInput);
        inputBuffer.AddCommandData(input);
    }
}

[UpdateInGroup(typeof(GhostPredictionSystemGroup))]
public class CameraRigSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var group = World.GetExistingSystem<GhostPredictionSystemGroup>();
        var tick = group.PredictingTick;

        var deltaTime = Time.DeltaTime;
        var entityManager = EntityManager;
        Entities.ForEach((Entity ent, DynamicBuffer<PilotInput> inputBuffer, ref PredictedGhostComponent prediction, in CameraRigChild cameraRigChild) =>
        {
            if (!GhostPredictionSystemGroup.ShouldPredict(tick, prediction))
                return;
            inputBuffer.GetDataAtTick(tick, out PilotInput input);
            
            entityManager.SetComponentData(ent, new CameraRigChild { 
                Value = cameraRigChild.Value,
                headPose = input.head.positon, 
                headRot = input.head.rotation,
                leftHandPose = input.leftHand.positon, 
                leftHandRot = input.leftHand.rotation,
                rightHandPose = input.rightHand.positon,
                rightHandRot = input.rightHand.rotation
            });
            var cameraRig = entityManager.GetComponentData<CameraRigData>(cameraRigChild.Value);
            entityManager.SetComponentData(cameraRig.head, new Translation { Value = cameraRigChild.headPose });
            entityManager.SetComponentData(cameraRig.head, new Rotation { Value = cameraRigChild.headRot });
            entityManager.SetComponentData(cameraRig.leftHand, new Translation { Value = cameraRigChild.leftHandPose });
            entityManager.SetComponentData(cameraRig.leftHand, new Rotation { Value = cameraRigChild.leftHandRot });
            entityManager.SetComponentData(cameraRig.rightHand, new Translation { Value = cameraRigChild.rightHandPose});
            entityManager.SetComponentData(cameraRig.rightHand, new Rotation { Value = cameraRigChild.rightHandRot });

        }).Run();
        
    }
}
[UpdateInGroup(typeof(ClientAndServerSimulationSystemGroup)), UpdateBefore(typeof(CameraRigSystem))]
public class CameraRigTransformSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var entityManager = EntityManager;
        Entities.ForEach((in CameraRigChild cameraRigChild) =>
        {
            if (cameraRigChild.Value == Entity.Null)
                return;
            var cameraRig = entityManager.GetComponentData<CameraRigData>(cameraRigChild.Value);
            entityManager.SetComponentData(cameraRig.head, new Translation { Value = cameraRigChild.headPose });
            entityManager.SetComponentData(cameraRig.head, new Rotation { Value = cameraRigChild.headRot });
            entityManager.SetComponentData(cameraRig.leftHand, new Translation { Value = cameraRigChild.leftHandPose });
            entityManager.SetComponentData(cameraRig.leftHand, new Rotation { Value = cameraRigChild.leftHandRot });
            entityManager.SetComponentData(cameraRig.rightHand, new Translation { Value = cameraRigChild.rightHandPose });
            entityManager.SetComponentData(cameraRig.rightHand, new Rotation { Value = cameraRigChild.rightHandRot });

        }).Run();
    }
}