using UnityEngine;

public interface ISpawns
{
    //ItemPickUps_SO[] itemDefinitions { get; set; }
    Rigidbody itemSpawned { get; set; }
    LootItem itemType { get; set; }
    Renderer itemMaterial { get; set; }

    void CreateSpawn();
}
