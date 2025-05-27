using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpawnSolarPanel : MonoBehaviour
{
    public GameObject solarPanel;
    public Vector3 spawnPosition;
    public int maxSpawnCount = 8;
    private int currentSpawnCount = 0;

    private List<GameObject> solarPanels;

    public void Start()
    {
        solarPanels = new List<GameObject>();
    }

    public void SpawnObject()
    {
        if (solarPanels.Count < maxSpawnCount)
        {
            solarPanels.Add(Instantiate(solarPanel, spawnPosition, Quaternion.identity));
        }
        else
        {
            UnityEngine.Debug.Log("Spawn limit");
        }
    }


    public List<GameObject> getSolarPanels()
    {
        return this.solarPanels;
    }

    public void destroyPanels()
    {
        foreach (var panelSolar in this.solarPanels)
        {
            Destroy(panelSolar);
        }

        solarPanels = new List<GameObject>();
    }
}
