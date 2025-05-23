using System.Diagnostics;
using UnityEngine;

public class SpawnSolarPanel : MonoBehaviour
{
    public GameObject solarPanel;
    public Vector3 spawnPosition;
    public int maxSpawnCount = 6;
    private int currentSpawnCount = 0;

    public void SpawnObject()
    {
        if (currentSpawnCount < maxSpawnCount)
        {
            Instantiate(solarPanel, spawnPosition, Quaternion.identity);
            currentSpawnCount++;
        }
        else
        {
            UnityEngine.Debug.Log("Spawn limit");
        }
    }
}
