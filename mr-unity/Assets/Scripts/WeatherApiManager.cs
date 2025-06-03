using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Fusion;
using System.Collections.Generic;

public class WeatherApiManager : NetworkBehaviour
{
   [Networked] public int BestAngle { get; set; }
   [Networked] public float TotalEnergy { get; set; }
   [Networked] public float TotalOptimalEnergy { get; set; }
   [Networked, Capacity(64)] public NetworkString<_64> City { get; set; }

   private SolarEnergyResponse localResponse = new SolarEnergyResponse();

   public override void Spawned()
   {
      // optional: auto-fetch when spawned if authority
      if (HasStateAuthority)
      {
         // example auto-fetch
         // callingSolarEnergyApi("Berlin", "30", "10");
      }
   }

   public void callingSolarEnergyApi(string location, string angle, string quantityPanel)
   {
      if (HasStateAuthority) // only fetch from one authoritative source
         StartCoroutine(GetData(location, angle, quantityPanel));
   }

   private IEnumerator GetData(string location, string angle, string quantityPanel)
   {
      string url = $"https://ms-solar-energy-dcdc-production.up.railway.app/panel/energy?location={location}&angle={angle}&quantityPanel={quantityPanel}";
      Debug.Log($"Requesting: {url}");

      using (UnityWebRequest request = UnityWebRequest.Get(url))
      {
         yield return request.SendWebRequest();

         if (request.result == UnityWebRequest.Result.Success)
         {
            string json = request.downloadHandler.text;
            SolarEnergyResponse response = JsonConvert.DeserializeObject<SolarEnergyResponse>(json);
            localResponse = response;

            Debug.Log("API Response: " + json);

            // Sync networked fields (basic data only)
            BestAngle = response.bestAngle;
            TotalEnergy = response.totalEnergy;
            TotalOptimalEnergy = response.totalOptimalEnergy;
            City = response.city;
         }
         else
         {
            Debug.LogError("API Error: " + request.error);
         }
      }
   }

   public SolarEnergyResponse GetLocalResponse()
   {
      return localResponse;
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