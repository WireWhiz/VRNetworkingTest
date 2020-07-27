using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Collections;
using Unity.NetCode;
using Unity.Transforms;

public struct PilotGhostSerializer : IGhostSerializer<PilotSnapshotData>
{
    private ComponentType componentTypeCameraRigChild;
    private ComponentType componentTypePilotData;
    private ComponentType componentTypePilotSetupRequired;
    private ComponentType componentTypeLocalToWorld;
    private ComponentType componentTypeRotation;
    private ComponentType componentTypeTranslation;
    // FIXME: These disable safety since all serializers have an instance of the same type - causing aliasing. Should be fixed in a cleaner way
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ArchetypeChunkComponentType<CameraRigChild> ghostCameraRigChildType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ArchetypeChunkComponentType<PilotData> ghostPilotDataType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ArchetypeChunkComponentType<Rotation> ghostRotationType;
    [NativeDisableContainerSafetyRestriction][ReadOnly] private ArchetypeChunkComponentType<Translation> ghostTranslationType;


    public int CalculateImportance(ArchetypeChunk chunk)
    {
        return 1;
    }

    public int SnapshotSize => UnsafeUtility.SizeOf<PilotSnapshotData>();
    public void BeginSerialize(ComponentSystemBase system)
    {
        componentTypeCameraRigChild = ComponentType.ReadWrite<CameraRigChild>();
        componentTypePilotData = ComponentType.ReadWrite<PilotData>();
        componentTypePilotSetupRequired = ComponentType.ReadWrite<PilotSetupRequired>();
        componentTypeLocalToWorld = ComponentType.ReadWrite<LocalToWorld>();
        componentTypeRotation = ComponentType.ReadWrite<Rotation>();
        componentTypeTranslation = ComponentType.ReadWrite<Translation>();
        ghostCameraRigChildType = system.GetArchetypeChunkComponentType<CameraRigChild>(true);
        ghostPilotDataType = system.GetArchetypeChunkComponentType<PilotData>(true);
        ghostRotationType = system.GetArchetypeChunkComponentType<Rotation>(true);
        ghostTranslationType = system.GetArchetypeChunkComponentType<Translation>(true);
    }

    public void CopyToSnapshot(ArchetypeChunk chunk, int ent, uint tick, ref PilotSnapshotData snapshot, GhostSerializerState serializerState)
    {
        snapshot.tick = tick;
        var chunkDataCameraRigChild = chunk.GetNativeArray(ghostCameraRigChildType);
        var chunkDataPilotData = chunk.GetNativeArray(ghostPilotDataType);
        var chunkDataRotation = chunk.GetNativeArray(ghostRotationType);
        var chunkDataTranslation = chunk.GetNativeArray(ghostTranslationType);
        snapshot.SetCameraRigChildheadPose(chunkDataCameraRigChild[ent].headPose, serializerState);
        snapshot.SetCameraRigChildheadRot(chunkDataCameraRigChild[ent].headRot, serializerState);
        snapshot.SetCameraRigChildleftHandPose(chunkDataCameraRigChild[ent].leftHandPose, serializerState);
        snapshot.SetCameraRigChildleftHandRot(chunkDataCameraRigChild[ent].leftHandRot, serializerState);
        snapshot.SetCameraRigChildrightHandPose(chunkDataCameraRigChild[ent].rightHandPose, serializerState);
        snapshot.SetCameraRigChildrightHandRot(chunkDataCameraRigChild[ent].rightHandRot, serializerState);
        snapshot.SetPilotDataPlayerId(chunkDataPilotData[ent].PlayerId, serializerState);
        snapshot.SetRotationValue(chunkDataRotation[ent].Value, serializerState);
        snapshot.SetTranslationValue(chunkDataTranslation[ent].Value, serializerState);
    }
}
