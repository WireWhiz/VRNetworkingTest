using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class HeadCamera : MonoBehaviour
{
    public void Start()
    {
        XRGeneralSettings.Instance.Manager.activeLoader.GetLoadedSubsystem<XRInputSubsystem>().TrySetTrackingOriginMode(TrackingOriginModeFlags.Floor);
        Application.onBeforeRender += () => {
            if (CameraRigEntity.Value == Entity.Null)
                return;
            var entMan = CameraRigEntity.World.EntityManager;
            var ent = entMan.GetComponentData<CameraRigData>(CameraRigEntity.Value).head;
            transform.position = entMan.GetComponentData<LocalToWorld>(ent).Position;
            transform.rotation = entMan.GetComponentData<LocalToWorld>(ent).Rotation;
        };
    }

}
