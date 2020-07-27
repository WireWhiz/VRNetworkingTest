using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[Serializable]
[GenerateAuthoringComponent]
public struct PilotData : IComponentData
{
    [GhostDefaultField]
    public int PlayerId;
    public bool clientHasAuthority;
}
