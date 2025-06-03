using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Newtonsoft.Json;
using Fusion;
using System.Drawing;
using OVRSimpleJSON;
using UnityEngine.Rendering.Universal;
using System;

public class WeatherApiManager : NetworkBehaviour
{
   [Networked] public string City { get; set; }
   [Networked] public string Angle { get; set; }
   [Networked] public string PanelCount { get; set; }
   [Networked] public string MemberCount { get; set; }
   [Networked] public int BestAngle { get; set; }

   [Networked] public float TotalEnergy { get; set; }
   [Networked] public float TotalOptimalEnergy { get; set; }

   public event Action OnCityChanged;
   public event Action OnControlUiChanged;

   private SolarEnergyResponse parsedResponse;

   private ChangeDetector _changeDetector;

   public override void Spawned()
   {
      _changeDetector = GetChangeDetector(ChangeDetector.Source.SimulationState);
   }

   [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
   public void RPC_RequestApiData(string city, string angle, string panelCount)
   {
      StartCoroutine(GetData(city, angle, panelCount));
   }

   [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
   public void RPC_SetControlUi(string angle, string memberCount, string panelCount)
   {
      Angle = angle;
      MemberCount = memberCount;
      PanelCount = panelCount;
   }

   public override void Render()
   {
      foreach (var change in _changeDetector.DetectChanges(this))
      {
         switch (change)
         {
            case nameof(City):
               Debug.LogWarning("Detected CHange");
               OnCityChanged?.Invoke();
               break;
            case nameof(Angle):
               Debug.LogWarning("Detected CHange");
               OnControlUiChanged?.Invoke();
               break;
            case nameof(PanelCount):
               Debug.LogWarning("Detected CHange");
               OnControlUiChanged?.Invoke();
               break;
            case nameof(MemberCount):
               Debug.LogWarning("Detected CHange");
               OnControlUiChanged?.Invoke();
               break;
         }
      }
   }

   public void ChangeCity(string city, string angle, string panelCount)
   {
      Debug.LogWarning("Changing City, HasStateAuthority: " + HasStateAuthority);

      RPC_RequestApiData(city, angle, panelCount);
   }

   public void SetControlUi(string angle, string members, string panelCount)
   {
      Debug.LogWarning("Changing angle, HasStateAuthority: " + HasStateAuthority);

      RPC_SetControlUi(angle, members, panelCount);
   }

   private IEnumerator GetData(string location, string angle, string quantityPanel)
   {
      Debug.LogWarning("Getting API DATA");

      string url = $"https://ms-solar-energy-dcdc-production.up.railway.app/panel/energy?location={location}&angle={angle}&quantityPanel={quantityPanel}";
      Debug.LogWarning($"Requesting: {url}"); 
      using (UnityWebRequest request = UnityWebRequest.Get(url))
      {
         yield return request.SendWebRequest();
         Debug.LogWarning("Sending Webrequest");

         if (request.result == UnityWebRequest.Result.Success)
         {
            string json = request.downloadHandler.text;
            Debug.LogWarning("API Response: " + json);
            SolarEnergyResponse response = JsonConvert.DeserializeObject<SolarEnergyResponse>(json);
            Debug.LogWarning("API Response deserialized: " + response);

            City = location;
            parsedResponse = JsonConvert.DeserializeObject<SolarEnergyResponse>(json);
            TotalEnergy = parsedResponse.totalEnergy;
            TotalOptimalEnergy = parsedResponse.totalOptimalEnergy;
            BestAngle = parsedResponse.bestAngle;

            Debug.LogWarning("API Success: " + json);
         }
         else
         {
            Debug.LogError("API Error: " + request.error);
         }
      }
   }
}

[System.Serializable]
public class MonthData
{
   public int year;
   public int month;
   public float temperature;
   public float energy;
   public float optimalEnergy;
}

[System.Serializable]
public class SolarEnergyResponse
{
   public int bestAngle;
   public string city;
   public List<MonthData> months;
   public float totalEnergy;
   public float totalOptimalEnergy;
}
