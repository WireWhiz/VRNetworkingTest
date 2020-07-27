using Unity.Networking.Transport;
using Unity.NetCode;
using Unity.Mathematics;

public struct PilotSnapshotData : ISnapshotData<PilotSnapshotData>
{
    public uint tick;
    private int CameraRigChildheadPoseX;
    private int CameraRigChildheadPoseY;
    private int CameraRigChildheadPoseZ;
    private int CameraRigChildheadRotX;
    private int CameraRigChildheadRotY;
    private int CameraRigChildheadRotZ;
    private int CameraRigChildheadRotW;
    private int CameraRigChildleftHandPoseX;
    private int CameraRigChildleftHandPoseY;
    private int CameraRigChildleftHandPoseZ;
    private int CameraRigChildleftHandRotX;
    private int CameraRigChildleftHandRotY;
    private int CameraRigChildleftHandRotZ;
    private int CameraRigChildleftHandRotW;
    private int CameraRigChildrightHandPoseX;
    private int CameraRigChildrightHandPoseY;
    private int CameraRigChildrightHandPoseZ;
    private int CameraRigChildrightHandRotX;
    private int CameraRigChildrightHandRotY;
    private int CameraRigChildrightHandRotZ;
    private int CameraRigChildrightHandRotW;
    private int PilotDataPlayerId;
    private int RotationValueX;
    private int RotationValueY;
    private int RotationValueZ;
    private int RotationValueW;
    private int TranslationValueX;
    private int TranslationValueY;
    private int TranslationValueZ;
    uint changeMask0;

    public uint Tick => tick;
    public float3 GetCameraRigChildheadPose(GhostDeserializerState deserializerState)
    {
        return GetCameraRigChildheadPose();
    }
    public float3 GetCameraRigChildheadPose()
    {
        return new float3(CameraRigChildheadPoseX * 0.001f, CameraRigChildheadPoseY * 0.001f, CameraRigChildheadPoseZ * 0.001f);
    }
    public void SetCameraRigChildheadPose(float3 val, GhostSerializerState serializerState)
    {
        SetCameraRigChildheadPose(val);
    }
    public void SetCameraRigChildheadPose(float3 val)
    {
        CameraRigChildheadPoseX = (int)(val.x * 1000);
        CameraRigChildheadPoseY = (int)(val.y * 1000);
        CameraRigChildheadPoseZ = (int)(val.z * 1000);
    }
    public quaternion GetCameraRigChildheadRot(GhostDeserializerState deserializerState)
    {
        return GetCameraRigChildheadRot();
    }
    public quaternion GetCameraRigChildheadRot()
    {
        return new quaternion(CameraRigChildheadRotX * 0.01f, CameraRigChildheadRotY * 0.01f, CameraRigChildheadRotZ * 0.01f, CameraRigChildheadRotW * 0.01f);
    }
    public void SetCameraRigChildheadRot(quaternion q, GhostSerializerState serializerState)
    {
        SetCameraRigChildheadRot(q);
    }
    public void SetCameraRigChildheadRot(quaternion q)
    {
        CameraRigChildheadRotX = (int)(q.value.x * 100);
        CameraRigChildheadRotY = (int)(q.value.y * 100);
        CameraRigChildheadRotZ = (int)(q.value.z * 100);
        CameraRigChildheadRotW = (int)(q.value.w * 100);
    }
    public float3 GetCameraRigChildleftHandPose(GhostDeserializerState deserializerState)
    {
        return GetCameraRigChildleftHandPose();
    }
    public float3 GetCameraRigChildleftHandPose()
    {
        return new float3(CameraRigChildleftHandPoseX * 0.001f, CameraRigChildleftHandPoseY * 0.001f, CameraRigChildleftHandPoseZ * 0.001f);
    }
    public void SetCameraRigChildleftHandPose(float3 val, GhostSerializerState serializerState)
    {
        SetCameraRigChildleftHandPose(val);
    }
    public void SetCameraRigChildleftHandPose(float3 val)
    {
        CameraRigChildleftHandPoseX = (int)(val.x * 1000);
        CameraRigChildleftHandPoseY = (int)(val.y * 1000);
        CameraRigChildleftHandPoseZ = (int)(val.z * 1000);
    }
    public quaternion GetCameraRigChildleftHandRot(GhostDeserializerState deserializerState)
    {
        return GetCameraRigChildleftHandRot();
    }
    public quaternion GetCameraRigChildleftHandRot()
    {
        return new quaternion(CameraRigChildleftHandRotX * 0.01f, CameraRigChildleftHandRotY * 0.01f, CameraRigChildleftHandRotZ * 0.01f, CameraRigChildleftHandRotW * 0.01f);
    }
    public void SetCameraRigChildleftHandRot(quaternion q, GhostSerializerState serializerState)
    {
        SetCameraRigChildleftHandRot(q);
    }
    public void SetCameraRigChildleftHandRot(quaternion q)
    {
        CameraRigChildleftHandRotX = (int)(q.value.x * 100);
        CameraRigChildleftHandRotY = (int)(q.value.y * 100);
        CameraRigChildleftHandRotZ = (int)(q.value.z * 100);
        CameraRigChildleftHandRotW = (int)(q.value.w * 100);
    }
    public float3 GetCameraRigChildrightHandPose(GhostDeserializerState deserializerState)
    {
        return GetCameraRigChildrightHandPose();
    }
    public float3 GetCameraRigChildrightHandPose()
    {
        return new float3(CameraRigChildrightHandPoseX * 0.001f, CameraRigChildrightHandPoseY * 0.001f, CameraRigChildrightHandPoseZ * 0.001f);
    }
    public void SetCameraRigChildrightHandPose(float3 val, GhostSerializerState serializerState)
    {
        SetCameraRigChildrightHandPose(val);
    }
    public void SetCameraRigChildrightHandPose(float3 val)
    {
        CameraRigChildrightHandPoseX = (int)(val.x * 1000);
        CameraRigChildrightHandPoseY = (int)(val.y * 1000);
        CameraRigChildrightHandPoseZ = (int)(val.z * 1000);
    }
    public quaternion GetCameraRigChildrightHandRot(GhostDeserializerState deserializerState)
    {
        return GetCameraRigChildrightHandRot();
    }
    public quaternion GetCameraRigChildrightHandRot()
    {
        return new quaternion(CameraRigChildrightHandRotX * 0.01f, CameraRigChildrightHandRotY * 0.01f, CameraRigChildrightHandRotZ * 0.01f, CameraRigChildrightHandRotW * 0.01f);
    }
    public void SetCameraRigChildrightHandRot(quaternion q, GhostSerializerState serializerState)
    {
        SetCameraRigChildrightHandRot(q);
    }
    public void SetCameraRigChildrightHandRot(quaternion q)
    {
        CameraRigChildrightHandRotX = (int)(q.value.x * 100);
        CameraRigChildrightHandRotY = (int)(q.value.y * 100);
        CameraRigChildrightHandRotZ = (int)(q.value.z * 100);
        CameraRigChildrightHandRotW = (int)(q.value.w * 100);
    }
    public int GetPilotDataPlayerId(GhostDeserializerState deserializerState)
    {
        return (int)PilotDataPlayerId;
    }
    public int GetPilotDataPlayerId()
    {
        return (int)PilotDataPlayerId;
    }
    public void SetPilotDataPlayerId(int val, GhostSerializerState serializerState)
    {
        PilotDataPlayerId = (int)val;
    }
    public void SetPilotDataPlayerId(int val)
    {
        PilotDataPlayerId = (int)val;
    }
    public quaternion GetRotationValue(GhostDeserializerState deserializerState)
    {
        return GetRotationValue();
    }
    public quaternion GetRotationValue()
    {
        return new quaternion(RotationValueX * 0.001f, RotationValueY * 0.001f, RotationValueZ * 0.001f, RotationValueW * 0.001f);
    }
    public void SetRotationValue(quaternion q, GhostSerializerState serializerState)
    {
        SetRotationValue(q);
    }
    public void SetRotationValue(quaternion q)
    {
        RotationValueX = (int)(q.value.x * 1000);
        RotationValueY = (int)(q.value.y * 1000);
        RotationValueZ = (int)(q.value.z * 1000);
        RotationValueW = (int)(q.value.w * 1000);
    }
    public float3 GetTranslationValue(GhostDeserializerState deserializerState)
    {
        return GetTranslationValue();
    }
    public float3 GetTranslationValue()
    {
        return new float3(TranslationValueX * 0.01f, TranslationValueY * 0.01f, TranslationValueZ * 0.01f);
    }
    public void SetTranslationValue(float3 val, GhostSerializerState serializerState)
    {
        SetTranslationValue(val);
    }
    public void SetTranslationValue(float3 val)
    {
        TranslationValueX = (int)(val.x * 100);
        TranslationValueY = (int)(val.y * 100);
        TranslationValueZ = (int)(val.z * 100);
    }

    public void PredictDelta(uint tick, ref PilotSnapshotData baseline1, ref PilotSnapshotData baseline2)
    {
        var predictor = new GhostDeltaPredictor(tick, this.tick, baseline1.tick, baseline2.tick);
        CameraRigChildheadPoseX = predictor.PredictInt(CameraRigChildheadPoseX, baseline1.CameraRigChildheadPoseX, baseline2.CameraRigChildheadPoseX);
        CameraRigChildheadPoseY = predictor.PredictInt(CameraRigChildheadPoseY, baseline1.CameraRigChildheadPoseY, baseline2.CameraRigChildheadPoseY);
        CameraRigChildheadPoseZ = predictor.PredictInt(CameraRigChildheadPoseZ, baseline1.CameraRigChildheadPoseZ, baseline2.CameraRigChildheadPoseZ);
        CameraRigChildheadRotX = predictor.PredictInt(CameraRigChildheadRotX, baseline1.CameraRigChildheadRotX, baseline2.CameraRigChildheadRotX);
        CameraRigChildheadRotY = predictor.PredictInt(CameraRigChildheadRotY, baseline1.CameraRigChildheadRotY, baseline2.CameraRigChildheadRotY);
        CameraRigChildheadRotZ = predictor.PredictInt(CameraRigChildheadRotZ, baseline1.CameraRigChildheadRotZ, baseline2.CameraRigChildheadRotZ);
        CameraRigChildheadRotW = predictor.PredictInt(CameraRigChildheadRotW, baseline1.CameraRigChildheadRotW, baseline2.CameraRigChildheadRotW);
        CameraRigChildleftHandPoseX = predictor.PredictInt(CameraRigChildleftHandPoseX, baseline1.CameraRigChildleftHandPoseX, baseline2.CameraRigChildleftHandPoseX);
        CameraRigChildleftHandPoseY = predictor.PredictInt(CameraRigChildleftHandPoseY, baseline1.CameraRigChildleftHandPoseY, baseline2.CameraRigChildleftHandPoseY);
        CameraRigChildleftHandPoseZ = predictor.PredictInt(CameraRigChildleftHandPoseZ, baseline1.CameraRigChildleftHandPoseZ, baseline2.CameraRigChildleftHandPoseZ);
        CameraRigChildleftHandRotX = predictor.PredictInt(CameraRigChildleftHandRotX, baseline1.CameraRigChildleftHandRotX, baseline2.CameraRigChildleftHandRotX);
        CameraRigChildleftHandRotY = predictor.PredictInt(CameraRigChildleftHandRotY, baseline1.CameraRigChildleftHandRotY, baseline2.CameraRigChildleftHandRotY);
        CameraRigChildleftHandRotZ = predictor.PredictInt(CameraRigChildleftHandRotZ, baseline1.CameraRigChildleftHandRotZ, baseline2.CameraRigChildleftHandRotZ);
        CameraRigChildleftHandRotW = predictor.PredictInt(CameraRigChildleftHandRotW, baseline1.CameraRigChildleftHandRotW, baseline2.CameraRigChildleftHandRotW);
        CameraRigChildrightHandPoseX = predictor.PredictInt(CameraRigChildrightHandPoseX, baseline1.CameraRigChildrightHandPoseX, baseline2.CameraRigChildrightHandPoseX);
        CameraRigChildrightHandPoseY = predictor.PredictInt(CameraRigChildrightHandPoseY, baseline1.CameraRigChildrightHandPoseY, baseline2.CameraRigChildrightHandPoseY);
        CameraRigChildrightHandPoseZ = predictor.PredictInt(CameraRigChildrightHandPoseZ, baseline1.CameraRigChildrightHandPoseZ, baseline2.CameraRigChildrightHandPoseZ);
        CameraRigChildrightHandRotX = predictor.PredictInt(CameraRigChildrightHandRotX, baseline1.CameraRigChildrightHandRotX, baseline2.CameraRigChildrightHandRotX);
        CameraRigChildrightHandRotY = predictor.PredictInt(CameraRigChildrightHandRotY, baseline1.CameraRigChildrightHandRotY, baseline2.CameraRigChildrightHandRotY);
        CameraRigChildrightHandRotZ = predictor.PredictInt(CameraRigChildrightHandRotZ, baseline1.CameraRigChildrightHandRotZ, baseline2.CameraRigChildrightHandRotZ);
        CameraRigChildrightHandRotW = predictor.PredictInt(CameraRigChildrightHandRotW, baseline1.CameraRigChildrightHandRotW, baseline2.CameraRigChildrightHandRotW);
        PilotDataPlayerId = predictor.PredictInt(PilotDataPlayerId, baseline1.PilotDataPlayerId, baseline2.PilotDataPlayerId);
        RotationValueX = predictor.PredictInt(RotationValueX, baseline1.RotationValueX, baseline2.RotationValueX);
        RotationValueY = predictor.PredictInt(RotationValueY, baseline1.RotationValueY, baseline2.RotationValueY);
        RotationValueZ = predictor.PredictInt(RotationValueZ, baseline1.RotationValueZ, baseline2.RotationValueZ);
        RotationValueW = predictor.PredictInt(RotationValueW, baseline1.RotationValueW, baseline2.RotationValueW);
        TranslationValueX = predictor.PredictInt(TranslationValueX, baseline1.TranslationValueX, baseline2.TranslationValueX);
        TranslationValueY = predictor.PredictInt(TranslationValueY, baseline1.TranslationValueY, baseline2.TranslationValueY);
        TranslationValueZ = predictor.PredictInt(TranslationValueZ, baseline1.TranslationValueZ, baseline2.TranslationValueZ);
    }

    public void Serialize(int networkId, ref PilotSnapshotData baseline, ref DataStreamWriter writer, NetworkCompressionModel compressionModel)
    {
        changeMask0 = (CameraRigChildheadPoseX != baseline.CameraRigChildheadPoseX ||
                                          CameraRigChildheadPoseY != baseline.CameraRigChildheadPoseY ||
                                          CameraRigChildheadPoseZ != baseline.CameraRigChildheadPoseZ) ? 1u : 0;
        changeMask0 |= (CameraRigChildheadRotX != baseline.CameraRigChildheadRotX ||
                                           CameraRigChildheadRotY != baseline.CameraRigChildheadRotY ||
                                           CameraRigChildheadRotZ != baseline.CameraRigChildheadRotZ ||
                                           CameraRigChildheadRotW != baseline.CameraRigChildheadRotW) ? (1u<<1) : 0;
        changeMask0 |= (CameraRigChildleftHandPoseX != baseline.CameraRigChildleftHandPoseX ||
                                           CameraRigChildleftHandPoseY != baseline.CameraRigChildleftHandPoseY ||
                                           CameraRigChildleftHandPoseZ != baseline.CameraRigChildleftHandPoseZ) ? (1u<<2) : 0;
        changeMask0 |= (CameraRigChildleftHandRotX != baseline.CameraRigChildleftHandRotX ||
                                           CameraRigChildleftHandRotY != baseline.CameraRigChildleftHandRotY ||
                                           CameraRigChildleftHandRotZ != baseline.CameraRigChildleftHandRotZ ||
                                           CameraRigChildleftHandRotW != baseline.CameraRigChildleftHandRotW) ? (1u<<3) : 0;
        changeMask0 |= (CameraRigChildrightHandPoseX != baseline.CameraRigChildrightHandPoseX ||
                                           CameraRigChildrightHandPoseY != baseline.CameraRigChildrightHandPoseY ||
                                           CameraRigChildrightHandPoseZ != baseline.CameraRigChildrightHandPoseZ) ? (1u<<4) : 0;
        changeMask0 |= (CameraRigChildrightHandRotX != baseline.CameraRigChildrightHandRotX ||
                                           CameraRigChildrightHandRotY != baseline.CameraRigChildrightHandRotY ||
                                           CameraRigChildrightHandRotZ != baseline.CameraRigChildrightHandRotZ ||
                                           CameraRigChildrightHandRotW != baseline.CameraRigChildrightHandRotW) ? (1u<<5) : 0;
        changeMask0 |= (PilotDataPlayerId != baseline.PilotDataPlayerId) ? (1u<<6) : 0;
        changeMask0 |= (RotationValueX != baseline.RotationValueX ||
                                           RotationValueY != baseline.RotationValueY ||
                                           RotationValueZ != baseline.RotationValueZ ||
                                           RotationValueW != baseline.RotationValueW) ? (1u<<7) : 0;
        changeMask0 |= (TranslationValueX != baseline.TranslationValueX ||
                                           TranslationValueY != baseline.TranslationValueY ||
                                           TranslationValueZ != baseline.TranslationValueZ) ? (1u<<8) : 0;
        writer.WritePackedUIntDelta(changeMask0, baseline.changeMask0, compressionModel);
        if ((changeMask0 & (1 << 0)) != 0)
        {
            writer.WritePackedIntDelta(CameraRigChildheadPoseX, baseline.CameraRigChildheadPoseX, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildheadPoseY, baseline.CameraRigChildheadPoseY, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildheadPoseZ, baseline.CameraRigChildheadPoseZ, compressionModel);
        }
        if ((changeMask0 & (1 << 1)) != 0)
        {
            writer.WritePackedIntDelta(CameraRigChildheadRotX, baseline.CameraRigChildheadRotX, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildheadRotY, baseline.CameraRigChildheadRotY, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildheadRotZ, baseline.CameraRigChildheadRotZ, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildheadRotW, baseline.CameraRigChildheadRotW, compressionModel);
        }
        if ((changeMask0 & (1 << 2)) != 0)
        {
            writer.WritePackedIntDelta(CameraRigChildleftHandPoseX, baseline.CameraRigChildleftHandPoseX, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildleftHandPoseY, baseline.CameraRigChildleftHandPoseY, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildleftHandPoseZ, baseline.CameraRigChildleftHandPoseZ, compressionModel);
        }
        if ((changeMask0 & (1 << 3)) != 0)
        {
            writer.WritePackedIntDelta(CameraRigChildleftHandRotX, baseline.CameraRigChildleftHandRotX, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildleftHandRotY, baseline.CameraRigChildleftHandRotY, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildleftHandRotZ, baseline.CameraRigChildleftHandRotZ, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildleftHandRotW, baseline.CameraRigChildleftHandRotW, compressionModel);
        }
        if ((changeMask0 & (1 << 4)) != 0)
        {
            writer.WritePackedIntDelta(CameraRigChildrightHandPoseX, baseline.CameraRigChildrightHandPoseX, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildrightHandPoseY, baseline.CameraRigChildrightHandPoseY, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildrightHandPoseZ, baseline.CameraRigChildrightHandPoseZ, compressionModel);
        }
        if ((changeMask0 & (1 << 5)) != 0)
        {
            writer.WritePackedIntDelta(CameraRigChildrightHandRotX, baseline.CameraRigChildrightHandRotX, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildrightHandRotY, baseline.CameraRigChildrightHandRotY, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildrightHandRotZ, baseline.CameraRigChildrightHandRotZ, compressionModel);
            writer.WritePackedIntDelta(CameraRigChildrightHandRotW, baseline.CameraRigChildrightHandRotW, compressionModel);
        }
        if ((changeMask0 & (1 << 6)) != 0)
            writer.WritePackedIntDelta(PilotDataPlayerId, baseline.PilotDataPlayerId, compressionModel);
        if ((changeMask0 & (1 << 7)) != 0)
        {
            writer.WritePackedIntDelta(RotationValueX, baseline.RotationValueX, compressionModel);
            writer.WritePackedIntDelta(RotationValueY, baseline.RotationValueY, compressionModel);
            writer.WritePackedIntDelta(RotationValueZ, baseline.RotationValueZ, compressionModel);
            writer.WritePackedIntDelta(RotationValueW, baseline.RotationValueW, compressionModel);
        }
        if ((changeMask0 & (1 << 8)) != 0)
        {
            writer.WritePackedIntDelta(TranslationValueX, baseline.TranslationValueX, compressionModel);
            writer.WritePackedIntDelta(TranslationValueY, baseline.TranslationValueY, compressionModel);
            writer.WritePackedIntDelta(TranslationValueZ, baseline.TranslationValueZ, compressionModel);
        }
    }

    public void Deserialize(uint tick, ref PilotSnapshotData baseline, ref DataStreamReader reader,
        NetworkCompressionModel compressionModel)
    {
        this.tick = tick;
        changeMask0 = reader.ReadPackedUIntDelta(baseline.changeMask0, compressionModel);
        if ((changeMask0 & (1 << 0)) != 0)
        {
            CameraRigChildheadPoseX = reader.ReadPackedIntDelta(baseline.CameraRigChildheadPoseX, compressionModel);
            CameraRigChildheadPoseY = reader.ReadPackedIntDelta(baseline.CameraRigChildheadPoseY, compressionModel);
            CameraRigChildheadPoseZ = reader.ReadPackedIntDelta(baseline.CameraRigChildheadPoseZ, compressionModel);
        }
        else
        {
            CameraRigChildheadPoseX = baseline.CameraRigChildheadPoseX;
            CameraRigChildheadPoseY = baseline.CameraRigChildheadPoseY;
            CameraRigChildheadPoseZ = baseline.CameraRigChildheadPoseZ;
        }
        if ((changeMask0 & (1 << 1)) != 0)
        {
            CameraRigChildheadRotX = reader.ReadPackedIntDelta(baseline.CameraRigChildheadRotX, compressionModel);
            CameraRigChildheadRotY = reader.ReadPackedIntDelta(baseline.CameraRigChildheadRotY, compressionModel);
            CameraRigChildheadRotZ = reader.ReadPackedIntDelta(baseline.CameraRigChildheadRotZ, compressionModel);
            CameraRigChildheadRotW = reader.ReadPackedIntDelta(baseline.CameraRigChildheadRotW, compressionModel);
        }
        else
        {
            CameraRigChildheadRotX = baseline.CameraRigChildheadRotX;
            CameraRigChildheadRotY = baseline.CameraRigChildheadRotY;
            CameraRigChildheadRotZ = baseline.CameraRigChildheadRotZ;
            CameraRigChildheadRotW = baseline.CameraRigChildheadRotW;
        }
        if ((changeMask0 & (1 << 2)) != 0)
        {
            CameraRigChildleftHandPoseX = reader.ReadPackedIntDelta(baseline.CameraRigChildleftHandPoseX, compressionModel);
            CameraRigChildleftHandPoseY = reader.ReadPackedIntDelta(baseline.CameraRigChildleftHandPoseY, compressionModel);
            CameraRigChildleftHandPoseZ = reader.ReadPackedIntDelta(baseline.CameraRigChildleftHandPoseZ, compressionModel);
        }
        else
        {
            CameraRigChildleftHandPoseX = baseline.CameraRigChildleftHandPoseX;
            CameraRigChildleftHandPoseY = baseline.CameraRigChildleftHandPoseY;
            CameraRigChildleftHandPoseZ = baseline.CameraRigChildleftHandPoseZ;
        }
        if ((changeMask0 & (1 << 3)) != 0)
        {
            CameraRigChildleftHandRotX = reader.ReadPackedIntDelta(baseline.CameraRigChildleftHandRotX, compressionModel);
            CameraRigChildleftHandRotY = reader.ReadPackedIntDelta(baseline.CameraRigChildleftHandRotY, compressionModel);
            CameraRigChildleftHandRotZ = reader.ReadPackedIntDelta(baseline.CameraRigChildleftHandRotZ, compressionModel);
            CameraRigChildleftHandRotW = reader.ReadPackedIntDelta(baseline.CameraRigChildleftHandRotW, compressionModel);
        }
        else
        {
            CameraRigChildleftHandRotX = baseline.CameraRigChildleftHandRotX;
            CameraRigChildleftHandRotY = baseline.CameraRigChildleftHandRotY;
            CameraRigChildleftHandRotZ = baseline.CameraRigChildleftHandRotZ;
            CameraRigChildleftHandRotW = baseline.CameraRigChildleftHandRotW;
        }
        if ((changeMask0 & (1 << 4)) != 0)
        {
            CameraRigChildrightHandPoseX = reader.ReadPackedIntDelta(baseline.CameraRigChildrightHandPoseX, compressionModel);
            CameraRigChildrightHandPoseY = reader.ReadPackedIntDelta(baseline.CameraRigChildrightHandPoseY, compressionModel);
            CameraRigChildrightHandPoseZ = reader.ReadPackedIntDelta(baseline.CameraRigChildrightHandPoseZ, compressionModel);
        }
        else
        {
            CameraRigChildrightHandPoseX = baseline.CameraRigChildrightHandPoseX;
            CameraRigChildrightHandPoseY = baseline.CameraRigChildrightHandPoseY;
            CameraRigChildrightHandPoseZ = baseline.CameraRigChildrightHandPoseZ;
        }
        if ((changeMask0 & (1 << 5)) != 0)
        {
            CameraRigChildrightHandRotX = reader.ReadPackedIntDelta(baseline.CameraRigChildrightHandRotX, compressionModel);
            CameraRigChildrightHandRotY = reader.ReadPackedIntDelta(baseline.CameraRigChildrightHandRotY, compressionModel);
            CameraRigChildrightHandRotZ = reader.ReadPackedIntDelta(baseline.CameraRigChildrightHandRotZ, compressionModel);
            CameraRigChildrightHandRotW = reader.ReadPackedIntDelta(baseline.CameraRigChildrightHandRotW, compressionModel);
        }
        else
        {
            CameraRigChildrightHandRotX = baseline.CameraRigChildrightHandRotX;
            CameraRigChildrightHandRotY = baseline.CameraRigChildrightHandRotY;
            CameraRigChildrightHandRotZ = baseline.CameraRigChildrightHandRotZ;
            CameraRigChildrightHandRotW = baseline.CameraRigChildrightHandRotW;
        }
        if ((changeMask0 & (1 << 6)) != 0)
            PilotDataPlayerId = reader.ReadPackedIntDelta(baseline.PilotDataPlayerId, compressionModel);
        else
            PilotDataPlayerId = baseline.PilotDataPlayerId;
        if ((changeMask0 & (1 << 7)) != 0)
        {
            RotationValueX = reader.ReadPackedIntDelta(baseline.RotationValueX, compressionModel);
            RotationValueY = reader.ReadPackedIntDelta(baseline.RotationValueY, compressionModel);
            RotationValueZ = reader.ReadPackedIntDelta(baseline.RotationValueZ, compressionModel);
            RotationValueW = reader.ReadPackedIntDelta(baseline.RotationValueW, compressionModel);
        }
        else
        {
            RotationValueX = baseline.RotationValueX;
            RotationValueY = baseline.RotationValueY;
            RotationValueZ = baseline.RotationValueZ;
            RotationValueW = baseline.RotationValueW;
        }
        if ((changeMask0 & (1 << 8)) != 0)
        {
            TranslationValueX = reader.ReadPackedIntDelta(baseline.TranslationValueX, compressionModel);
            TranslationValueY = reader.ReadPackedIntDelta(baseline.TranslationValueY, compressionModel);
            TranslationValueZ = reader.ReadPackedIntDelta(baseline.TranslationValueZ, compressionModel);
        }
        else
        {
            TranslationValueX = baseline.TranslationValueX;
            TranslationValueY = baseline.TranslationValueY;
            TranslationValueZ = baseline.TranslationValueZ;
        }
    }
    public void Interpolate(ref PilotSnapshotData target, float factor)
    {
        SetCameraRigChildheadPose(math.lerp(GetCameraRigChildheadPose(), target.GetCameraRigChildheadPose(), factor));
        SetCameraRigChildheadRot(math.slerp(GetCameraRigChildheadRot(), target.GetCameraRigChildheadRot(), factor));
        SetCameraRigChildleftHandPose(math.lerp(GetCameraRigChildleftHandPose(), target.GetCameraRigChildleftHandPose(), factor));
        SetCameraRigChildleftHandRot(math.slerp(GetCameraRigChildleftHandRot(), target.GetCameraRigChildleftHandRot(), factor));
        SetCameraRigChildrightHandPose(math.lerp(GetCameraRigChildrightHandPose(), target.GetCameraRigChildrightHandPose(), factor));
        SetCameraRigChildrightHandRot(math.slerp(GetCameraRigChildrightHandRot(), target.GetCameraRigChildrightHandRot(), factor));
        SetRotationValue(math.slerp(GetRotationValue(), target.GetRotationValue(), factor));
        SetTranslationValue(math.lerp(GetTranslationValue(), target.GetTranslationValue(), factor));
    }
}
