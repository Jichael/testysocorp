using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private Transform toRotate;

    public void Rotate(float angle)
    {
        toRotate.Rotate(angle, 0, 0);
    }
}
