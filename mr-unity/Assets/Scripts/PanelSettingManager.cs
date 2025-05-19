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

   

    [SerializeField] private int angleInterval=25;
    private WeatherApiManager weatherApiManager;

    
    
    private int currentAngle = 0;
    private int currentPanel = 0;
    private int currentMember = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weatherApiManager = GameObject.Find("WeatherApiManager").GetComponent<WeatherApiManager>();
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
    }
    
    public void OnToggleChanged()
    {
        Toggle toggle = GetComponent<Toggle>();
        _txtTotalEnergy.text = toggle.name;
    }

    public void ChangeAngle(string type)
    {

        switch (type)
        {
           case "1":
                if (currentAngle < 90)
                {
                    currentAngle=currentAngle+angleInterval;
                }
                _txtAngle.text = currentAngle.ToString();
                break;
           
           case "0":
               if (currentAngle > 0)
               {
                   currentAngle=currentAngle-angleInterval;
               }

               _txtAngle.text = currentAngle.ToString();
               break;
            
            default:
                break;
        }
        
    }
    
    
    public void ChangePanel(string type)
    {

        switch (type)
        {
            case "1":
                currentPanel++;
                _txtPanel.text = currentPanel.ToString();
                break;
           
            case "0":
                if (currentPanel > 0)
                {
                    currentPanel--;
                }

                _txtPanel.text = currentPanel.ToString();
                break;
            
            default:
                break;
        }
        
    }
    
    
    public void ChangeMember(string type)
    {

        switch (type)
        {
            case "1":
                currentMember++;
                _txtMember.text = currentMember.ToString();
                break;
           
            case "0":
                if (currentMember > 0)
                {
                    currentMember--;
                }

                _txtMember.text = currentMember.ToString();
                break;
            
            default:
                break;
        }
        
    }


}
