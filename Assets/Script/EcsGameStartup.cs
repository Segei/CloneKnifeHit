using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;

public class EcsGameStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();
        _systems.Init();


    }
}
