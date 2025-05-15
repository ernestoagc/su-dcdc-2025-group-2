using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherApiManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetData());
        
    }
    
   private IEnumerator GetData()
    {
        string url = "https://ms-solar-energy-dcdc-production.up.railway.app/panel/energy?location=MAD&angle=38"; // Reemplaza con tu URL
        
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Respuesta: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error: " + request.error);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
