using UnityEngine;
//using Systems

public class RoofControll : MonoBehaviour
{
    public GameObject roof15;


    public void whenButtonClicked()
    {
        if (roof15 == true)
            roof15.SetActive(false);
        else
            roof15.SetActive(true);
    }
}
