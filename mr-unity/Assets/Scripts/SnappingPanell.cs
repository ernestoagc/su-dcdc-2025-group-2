using System.Diagnostics;
using UnityEngine;

public class SnappingPanell : MonoBehaviour
{
   // private bool isSnapped = false;

    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Hello: ");

        if (other.CompareTag("SnapZone"))
        {
            

            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
           // isSnapped = true;
            UnityEngine.Debug.Log("hilll: ");
        }
    }
}
