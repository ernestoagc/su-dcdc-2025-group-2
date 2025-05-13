using UnityEngine;
using UnityEngine.UI;

public class RoofSliderController : MonoBehaviour
{
    public Transform hingePoint; // Fixed part of roof
    public Transform movingPart; // The part that changes height
    public Slider roofSlider;

    // Define 3 roof angles (degrees)
    public float[] snapAngles = new float[] { 15f, 30f, 45f };
    private float roofLength = 2f; // Distance from hinge to moving part on XZ

    private void Start()
    {
        if (roofSlider != null)
            roofSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float index)
    {
        int i = Mathf.RoundToInt(index);
        float angle = snapAngles[i];

        ApplyAngle(angle);
    }

    void ApplyAngle(float angle)
    {
        // Convert angle to radians
        float radians = angle * Mathf.Deg2Rad;

        // Keep hinge point fixed, move the roof's movable side
        // Assuming roof rotates around X-axis (change in Y due to angle)
        float height = Mathf.Tan(radians) * roofLength;

        Vector3 hingePos = hingePoint.position;

        // Move moving part in local Y to get angle, keeping X/Z same
        Vector3 newPos = new Vector3(
            movingPart.position.x,
            hingePos.y + height,
            movingPart.position.z
        );

        movingPart.position = newPos;
    }
}
