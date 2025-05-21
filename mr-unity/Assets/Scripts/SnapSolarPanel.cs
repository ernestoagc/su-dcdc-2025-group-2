using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapSolarPanel : MonoBehaviour
{
    public Transform snapTarget;

    private bool isSnapped = false;

    private void OnTriggerEnter(Collider other)
    {
        // Only snap if not already snapped and the other object has SnapZone tag
        if (isSnapped || !other.CompareTag("SnapZone"))
            return;

        // Use the transform of the SnapZone as target
        snapTarget = other.transform;

        // Snap position and rotation
        transform.position = snapTarget.position;
        transform.rotation = snapTarget.rotation;

        // Optional: freeze the object in place
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = true;
        }

        isSnapped = true;
    }
}