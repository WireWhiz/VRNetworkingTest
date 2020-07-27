using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Networking.Transport;
using Unity.Transforms;
using UnityEngine;

// When client has a connection with network id, go in game and tell server to also go in game
[UpdateInGroup(typeof(ClientSimulationSystemGroup))]
public class GoInGameClientSystem : SystemBase
{
    protected override void OnCreate()
    {
    }

    protected override void OnUpdate()
    {
        EntityManager entityManager = EntityManager;
        Entities.WithStructuralChanges().WithNone<NetworkStreamInGame>().ForEach((Entity ent, ref NetworkIdComponent id) =>
        {
            entityManager.AddComponent<NetworkStreamInGame>(ent);
            var req = entityManager.CreateEntity();
            entityManager.AddComponent<GoInGameRequest>(req);
            entityManager.AddComponent<SendRpcCommandRequestComponent>(req);
            entityManager.SetComponentData(req, new SendRpcCommandRequestComponent { TargetConnection = ent });
        }).Run();
    }
    // When server receives go in game request, go in game and delete request
    [UpdateInGroup(typeof(ServerSimulationSystemGroup))]
    public class GoInGameServerSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityManager entityManager = EntityManager;
            Entities.WithStructuralChanges().WithNone<SendRpcCommandRequestComponent>().ForEach((Entity reqEnt, ref GoInGameRequest req, ref ReceiveRpcCommandRequestComponent reqSrc) =>
            {
                entityManager.AddComponent<NetworkStreamInGame>(reqSrc.SourceConnection);
                UnityEngine.Debug.Log(System.String.Format("Server setting connection {0} to in game", EntityManager.GetComponentData<NetworkIdComponent>(reqSrc.SourceConnection).Value));
                var ghostCollection = GetSingleton<GhostPrefabCollectionComponent>();
                
                var ghostId = PlayersGhostSerializerCollection.FindGhostType<PilotSnapshotData>();
                var prefab = EntityManager.GetBuffer<GhostPrefabBuffer>(ghostCollection.serverPrefabs)[ghostId].Value;
                var player = entityManager.Instantiate( prefab);
                entityManager.SetComponentData( player, new PilotData { PlayerId = EntityManager.GetComponentData<NetworkIdComponent>(reqSrc.SourceConnection).Value });
                entityManager.AddBuffer<PilotInput>( player);

                entityManager.SetComponentData( reqSrc.SourceConnection, new CommandTargetComponent { targetEntity = player });
                
                
                entityManager.DestroyEntity( reqEnt);
                Debug.Log("Spawend Player");
            }).Run();
        }
    }

}

[BurstCompile]
public struct GoInGameRequest : IRpcCommand
{
    public void Deserialize(ref DataStreamReader reader)
    {
    }

    public void Serialize(ref DataStreamWriter writer)
    {
    }
    [BurstCompile]
    private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
    {
        RpcExecutor.ExecuteCreateRequestComponent<GoInGameRequest>(ref parameters);
    }

    static PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);
    public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
    {
        return InvokeExecuteFunctionPointer;
    }
}

// The system that makes the RPC request component transfer
public class GoInGameRequestSystem : RpcCommandRequestSystem<GoInGameRequest>
{
}
