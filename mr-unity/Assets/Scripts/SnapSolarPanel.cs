using UnityEngine;

public class SnapSolarPanel : MonoBehaviour
{
    private bool isSnapped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isSnapped) return;

        if (other.CompareTag("SnapZone"))
        {
            
            Transform snapPoint = other.transform;

            transform.position = snapPoint.position;
            transform.rotation = snapPoint.rotation;

            isSnapped = true;

        }
    }
}
