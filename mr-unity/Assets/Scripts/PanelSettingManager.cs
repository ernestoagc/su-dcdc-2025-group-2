using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Meta.XR.MRUtilityKit;
using UnityEngine.UI;
public class PanelSettingManager : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField _txtAngle;
    [SerializeField] private TMP_InputField _txtMember;
    [SerializeField] private TMP_InputField _txtPanel;
    [SerializeField] private TMP_InputField _txtTotalEnergy;
    
    [SerializeField] private TextMeshProUGUI _lblConsumptionEnergy;
    [SerializeField] private TextMeshProUGUI _lblCity;
    [SerializeField] private TextMeshProUGUI _lblAngle;
    [SerializeField] private TextMeshProUGUI _lblTotalPanelEnergy;
    
    
    [SerializeField] private List<GameObject> roofAssets;
    //private List<GameObject> panels;
    [SerializeField] private SpawnSolarPanel spawnSolarPanel;
    //[SerializeField] private GameObject roofPanel15;
    //[SerializeField] private GameObject roofSnap15;
    //[SerializeField] private GameObject roofPanel30;
    //[SerializeField] private GameObject roofSnap30;

    [SerializeField] private int angleInterval=15;
    
    [SerializeField] private int energyConsumptionAverage=100;
    private WeatherApiManager weatherApiManager;

    
    
    private int currentAngle = 0;
    private int currentMember = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weatherApiManager = GameObject.Find("WeatherApiManager").GetComponent<WeatherApiManager>();
        _lblConsumptionEnergy.text = energyConsumptionAverage.ToString();
        //spawnSolarPanel = GameObject.Find("SpawnSolarPanel").GetComponent<SpawnSolarPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
    }
    
    public void OnCityChange(string city)
    {
       
        // Aquí puedes acceder al GameObject o un ID personalizado
        weatherApiManager.callingSolarEnergyApi(city,_txtAngle.text, _txtPanel.text );
        SolarEnergyResponse response = weatherApiManager.getSolarEnergyResponse();

        _txtTotalEnergy.text = response.totalEnergy.ToString();
        _lblTotalPanelEnergy.text= response.totalEnergy.ToString();
        
        _lblCity.text = response.city;
    }
    


    public void ChangeAngle(string type)
    {

        switch (type)
        {
           case "1":
                if (currentAngle < 75)
                {
                    currentAngle=currentAngle+angleInterval;
                }
                showRoofAsset(currentAngle);
                destroyPanels();
                _txtAngle.text = currentAngle.ToString();
                _lblAngle.text = currentAngle.ToString();
                break;
           
           case "0":
               if (currentAngle > 0)
               {
                   currentAngle=currentAngle-angleInterval;
               }

               showRoofAsset(currentAngle);
               destroyPanels();
               _txtAngle.text = currentAngle.ToString();
               _lblAngle.text = currentAngle.ToString();
               break;
            
            default:
                showRoofAsset(currentAngle);
                break;
        }
        
    }

    private void showRoofAsset(int currentAngle)
    {
        
        switch (currentAngle)
        {
            case 15:
                foreach (var asset in roofAssets)
                {
                    if (asset.CompareTag("PanelRoof15"))
                    {
                        asset.SetActive(true);
                    }
                    else
                    {
                        asset.SetActive(false);
                    }
                }
                break;
           
            case 30:
                foreach (var asset in roofAssets)
                {
                    if (asset.CompareTag("PanelRoof30"))
                    {
                        asset.SetActive(true);
                    }
                    else
                    {
                        asset.SetActive(false);
                    }
                }
                break;
            case 45:
                foreach (var asset in roofAssets)
                {
                    if (asset.CompareTag("PanelRoof45"))
                    {
                        asset.SetActive(true);
                    }
                    else
                    {
                        asset.SetActive(false);
                    }
                }
                break;
            case 60:
                foreach (var asset in roofAssets)
                {
                    if (asset.CompareTag("PanelRoof60"))
                    {
                        asset.SetActive(true);
                    }
                    else
                    {
                        asset.SetActive(false);
                    }
                }
                break;
            case 75:
                foreach (var asset in roofAssets)
                {
                    if (asset.CompareTag("PanelRoof75"))
                    {
                        asset.SetActive(true);
                    }
                    else
                    {
                        asset.SetActive(false);
                    }
                }
                break;
            
            default:
                foreach (var asset in roofAssets)
                {
                        asset.SetActive(false);
                }
                break;
        }
        
    }

    private void destroyPanels()
    {
        spawnSolarPanel.destroyPanels();
        _txtPanel.text =spawnSolarPanel.getSolarPanels().Count.ToString();
    }



    public void AddPanel()
    {
        spawnSolarPanel.SpawnObject();
        _txtPanel.text =spawnSolarPanel.getSolarPanels().Count.ToString();
        
    }


    public void ChangeMember(string type)
    {

        switch (type)
        {
            case "1":
                currentMember++;
                _lblConsumptionEnergy.text = (energyConsumptionAverage*currentMember).ToString();
                _txtMember.text = currentMember.ToString();
                break;
           
            case "0":
                if (currentMember > 0)
                {
                    currentMember--;
                }

                _lblConsumptionEnergy.text = (energyConsumptionAverage*currentMember).ToString();
                _txtMember.text = currentMember.ToString();
                break;
            
            default:
                break;
        }
        
    }


}
