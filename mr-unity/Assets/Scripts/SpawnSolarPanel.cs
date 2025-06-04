using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static Unity.Collections.Unicode;

public class SpawnSolarPanel : MonoBehaviour
{
   public GameObject solarPanel;
   public Vector3 spawnPosition;
   public int maxSpawnCount = 8;
   public int currentSpawnCount = 0;

   public List<GameObject> solarPanels;

   public void Start()
   {
      solarPanels = new List<GameObject>();
   }

   public List<GameObject> getSolarPanels()
   {
      return this.solarPanels;
   }

   public void destroyPanels()
   {
      currentSpawnCount = 0;
      foreach (var panelSolar in this.solarPanels)
      {
         Destroy(panelSolar);
      }

      solarPanels = new List<GameObject>();
   }
}
