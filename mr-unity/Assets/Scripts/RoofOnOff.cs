using UnityEngine;

public class RoofOnOff : MonoBehaviour
{
    public GameObject roofObject;

    public void EnableTarget()
    {
        roofObject.SetActive(true);
    }
}
