using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapSolarPanel : MonoBehaviour
{
    private bool isSnapped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isSnapped) return;

        if (other.CompareTag("SnapZone"))
        {
            // Snap to the snap zone's position and rotation
            Transform snapPoint = other.transform;

            transform.position = snapPoint.position;
            transform.rotation = snapPoint.rotation;

            isSnapped = true;


        }

    }
}