using UnityEngine;

public class TrashBin : MonoBehaviour
{
    // Set this in the Inspector or use a constant
    public string destroyTag = "Trash";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(destroyTag))
        {
            Destroy(other.gameObject);
            Debug.Log($"Destroyed: {other.name}");
        }
    }
}