using System.Collections;
using UnityEngine;

public class PropsVisibility : MonoBehaviour
{
    [SerializeField] private GameObject[] props;

    private void OnValidate()
    {
        Transform t = transform;
        props = new GameObject[t.childCount];
        for (int i = 0; i < props.Length; i++)
        {
            props[i] = t.GetChild(i).gameObject;
        }
    }

    private void Awake()
    {
        StartCoroutine(PropsVisibilityCo());
    }

    private IEnumerator PropsVisibilityCo()
    {
        for (int i = 0; i < props.Length; i++)
        {
            if (i % 10 == 0) yield return null;
            props[i].SetActive(Random.Range(0, 2) == 1);
        }
    }
}
