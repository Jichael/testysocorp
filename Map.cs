using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Map : MonoBehaviour
{
    public static Map Instance { get; private set; }
    
    public float rotationSpeed;
    [SerializeField] private float speedIncrease;
    
    [SerializeField] private Segment[] segmentPrefabs;
    private float _speedIncreaseTimer;

    private readonly List<Segment> _segments = new List<Segment>();

    private void Awake()
    {
        Instance = this;
        Segment[] children = GetComponentsInChildren<Segment>();
        for (var i = 0; i < children.Length; i++)
        {
            Segment child = children[i];
            _segments.Add(child);
        }
    }

    private void Start()
    {
        Player.Instance.SetSpeed(-rotationSpeed);
    }

    private void Update()
    {
        float angle = rotationSpeed * Time.deltaTime;
        for (int i = 0; i < _segments.Count; i++)
        {
            _segments[i].Rotate(angle);
        }

        _speedIncreaseTimer += Time.deltaTime;

        if (_speedIncreaseTimer > 2)
        {
            _speedIncreaseTimer = 0;
            rotationSpeed *= speedIncrease;
            Player.Instance.SetSpeed(-rotationSpeed);
        }
    }

    public void RemoveSegment(Segment seg)
    {
        _segments.Remove(seg);
        AddSegment(seg.transform.rotation);
        Destroy(seg.gameObject);
    }

    private void AddSegment(Quaternion angle)
    {
        Segment seg = Instantiate(segmentPrefabs[Random.Range(0, segmentPrefabs.Length)], transform);
        Transform t = seg.transform;
        t.localPosition = Vector3.zero;
        t.rotation = angle;
        _segments.Add(seg);
    }

    public void EndGame()
    {
        StartCoroutine(EndGameCo());
    }

    private IEnumerator EndGameCo()
    {
        while (!Mathf.Approximately(rotationSpeed, 0))
        {
            rotationSpeed = Mathf.MoveTowards(rotationSpeed, 0, Mathf.Max(20, Mathf.Abs(rotationSpeed * 0.4f) * Time.deltaTime));
            yield return null;
        }

        rotationSpeed = 0;
    }

}
