using UnityEngine;

public class RespawnOnDeath : Death
{
    public override void Die()
    {
        // Pick a random respawn point
        Vector3 spawnPos = GameManager.instance.GetRespawnPoint().position;

        // Spawn a new player at that position
        GameManager.instance.SpawnPlayer(spawnPos);

        // Destroy the old pawn so it stops calling Die()
        //Destroy(gameObject);
    }
}
