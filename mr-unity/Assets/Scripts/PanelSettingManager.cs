using UnityEngine;
using TMPro;
using Fusion;
using System.Collections.Generic;
using System.Collections;
using System;

public class PanelSettingManager : NetworkBehaviour
{
   [SerializeField] private TMP_InputField _txtAngle;
   [SerializeField] private TMP_InputField _txtMember;
   [SerializeField] private TMP_InputField _txtPanel;
   [SerializeField] private TMP_InputField _txtTotalEnergy;

   [SerializeField] private TextMeshProUGUI _lblConsumptionEnergy;
   [SerializeField] private TextMeshProUGUI _lblCity;
   [SerializeField] private TextMeshProUGUI _lblAngle;
   [SerializeField] private TextMeshProUGUI _lblTotalPanelEnergy;
   [SerializeField] private TextMeshProUGUI _lblEnergyEfficiency;
   [SerializeField] private TextMeshProUGUI _lblPrice;

   [SerializeField] private SpawnSolarPanel spawnSolarPanel;
   [SerializeField] private List<GameObject> roofAssets;

   [SerializeField] private int angleInterval = 15;
   [SerializeField] private int energyConsumptionAverage = 100;

   private WeatherApiManager weatherApiManager;
   private int currentAngle = 0;
   private int currentMember = 0;

   void Start()
   {
      weatherApiManager = FindAnyObjectByType<WeatherApiManager>();
      weatherApiManager.OnCityChanged += UpdateTabletUiFromResponse;
      weatherApiManager.OnControlUiChanged += UpdateControlUiFromResponse;
   }

   private void UpdateTabletUiFromResponse()
   {
      if (weatherApiManager != null)
      {
         _lblTotalPanelEnergy.text = weatherApiManager.TotalEnergy + " KW/Year";
         _lblEnergyEfficiency.text = weatherApiManager.TotalOptimalEnergy > 0 ? (weatherApiManager.TotalEnergy / weatherApiManager.TotalOptimalEnergy * 100f).ToString("F2") : "0" + " %";
         _lblPrice.text = (int.Parse(_txtPanel.text) * 6000) + " SEK";
         _lblCity.text = weatherApiManager.City;
      }
   }

   private void UpdateControlUiFromResponse()
   {
      if (weatherApiManager != null)
      {
         if (int.Parse(weatherApiManager.PanelCount) < int.Parse(_txtPanel.text))
         {
            spawnSolarPanel.destroyPanels();
         }
         else if (HasStateAuthority && int.Parse(weatherApiManager.PanelCount) > int.Parse(_txtPanel.text))
         {
            
         }

         _txtAngle.text = weatherApiManager.Angle;
         _txtPanel.text = weatherApiManager.PanelCount;
         _txtMember.text = weatherApiManager.MemberCount;

         currentAngle = int.Parse(_txtAngle.text);
         showRoofAsset(currentAngle);
      }
   }

   public void OnCityChange(string city)
   {
      if (weatherApiManager != null)
      {
         weatherApiManager.ChangeCity(city, _txtAngle.text, _txtPanel.text);
      }
      else
      {
         Debug.LogError("WeatherAPIManager not found.");
      }
   }

   public void ChangeAngle(string type)
   {
      Debug.LogWarning("Changing angle");
      switch (type)
      {
         case "1":
            if (currentAngle < 75)
            {
               currentAngle = currentAngle + angleInterval;
            }
            showRoofAsset(currentAngle);
            destroyPanels();
            _txtAngle.text = currentAngle.ToString();
            _lblAngle.text = currentAngle.ToString();
            break;

         case "0":
            if (currentAngle > 0)
            {
               currentAngle = currentAngle - angleInterval;
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

      weatherApiManager.Angle = currentAngle.ToString();
      weatherApiManager.RPC_SetControlUi(_txtAngle.text, _txtMember.text, _txtPanel.text);
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
      _txtPanel.text = spawnSolarPanel.getSolarPanels().Count.ToString();
      weatherApiManager.RPC_SetControlUi(_txtAngle.text, _txtMember.text, _txtPanel.text);
   }



   public void AddPanel()
   {
      Debug.LogWarning("Adding Panel");
      spawnSolarPanel.solarPanels.Add(Runner.Spawn(spawnSolarPanel.solarPanel, spawnSolarPanel.spawnPosition, Quaternion.identity).gameObject);

      _txtPanel.text = spawnSolarPanel.getSolarPanels().Count.ToString();
      weatherApiManager.RPC_SetControlUi(_txtAngle.text, _txtMember.text, _txtPanel.text);
   }


   public void ChangeMember(string type)
   {
      Debug.LogWarning("Changing members");

      switch (type)
      {
         case "1":
            currentMember++;
            _lblConsumptionEnergy.text = (energyConsumptionAverage * currentMember).ToString();
            _txtMember.text = currentMember.ToString();
            break;

         case "0":
            if (currentMember > 0)
            {
               currentMember--;
            }

            _lblConsumptionEnergy.text = (energyConsumptionAverage * currentMember).ToString();
            _txtMember.text = currentMember.ToString();
            break;

         default:
            break;
      }

   }
}
