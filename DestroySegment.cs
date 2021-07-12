using UnityEngine;

public class DestroySegment : MonoBehaviour
{
    public bool ShouldDestroy { get; set; } = true;
    
    private void OnTriggerExit(Collider other)
    {
        Segment seg = other.GetComponent<Segment>();
        if (seg != null)
        {
            Map.Instance.RemoveSegment(seg);
        }
    }
}
