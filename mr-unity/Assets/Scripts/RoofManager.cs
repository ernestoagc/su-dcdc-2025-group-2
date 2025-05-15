using UnityEngine;

public class RoofManager : MonoBehaviour
{
    public GameObject[] roofs;

    public void activeRoof(int index)
    {
        for (int i = 0; i < roofs.Length; i++)
        {
            roofs[i].SetActive(i == index);
        }
    }
}
