using UnityEngine;

public class RespawnOnDeath : Death
{
    public override void Die()
    {
        // Pick a random respawn position
        Vector3 spawnPos = GameManager.instance.GetRespawnPoint().position;

        // Spawn a new player at the random spawn position
        GameManager.instance.SpawnPlayer(spawnPos);

        // Destroy the current player object
        Destroy(gameObject);
    }
}
