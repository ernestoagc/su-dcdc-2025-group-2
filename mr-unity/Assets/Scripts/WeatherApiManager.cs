using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Newtonsoft.Json;

public class WeatherApiManager : MonoBehaviour
{
    
    private SolarEnergyResponse objSolarEnergy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objSolarEnergy = new SolarEnergyResponse();
        //StartCoroutine(GetData());

    }
    
   private IEnumerator GetData(string location, string angle, string quantityPanel)
    {
        string url = "https://ms-solar-energy-dcdc-production.up.railway.app/panel/energy?location="
                     + location+"&angle="+angle + "&quantityPanel=" + quantityPanel; // Reemplaza con tu URL
        
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                
                string json = request.downloadHandler.text;

                // Parsear el JSON a tu clase
                SolarEnergyResponse response = JsonConvert.DeserializeObject<SolarEnergyResponse>(json);
                objSolarEnergy = response;
                Debug.Log("Respuesta: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error: " + request.error);
            }
        }
    }

    public void callingSolarEnergyApi(string location, string angle,string quantityPanel)
    {
        StartCoroutine(GetData(location,angle,quantityPanel));
    }

    public SolarEnergyResponse getSolarEnergyResponse()
    {
        return objSolarEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
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