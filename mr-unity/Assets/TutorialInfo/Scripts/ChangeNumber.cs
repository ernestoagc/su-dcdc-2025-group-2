using TMPro;
using UnityEngine;

public class NumberDisplayController : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private int currentValue = 1;
    public int minValue = 1;

    void Start()
    {
        UpdateDisplay();
    }

    public void Increase()
    {
        currentValue++;
        UpdateDisplay();
    }

    public void Decrease()
    {
        if (currentValue > minValue)
        {
            currentValue--;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        numberText.text = currentValue.ToString();
    }
}