using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelSnapVer2 : MonoBehaviour
{
    private bool isSnapped = false;
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSnapped || !other.CompareTag("SnapZone")) return;

        Transform snapTarget = other.transform;
        transform.position = snapTarget.position;
        transform.rotation = snapTarget.rotation;

        rb.isKinematic = true;
        isSnapped = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        rb.isKinematic = false;
        isSnapped = false;
    }
}
