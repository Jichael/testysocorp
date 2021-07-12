using UnityEngine;

public class BlockStateGroup : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    private void Awake()
    {
        if (Mathf.Abs(Map.Instance.rotationSpeed) < 35)
        {
            blocks[Random.Range(0, blocks.Length)].gameObject.SetActive(false);
        }
        else
        {
            int r = Random.Range(0, blocks.Length);
            int r2;
            do
            {
                r2 = Random.Range(0, blocks.Length);
            } while (r2 == r);
            blocks[r].gameObject.SetActive(false);
            blocks[r2].gameObject.SetActive(false);
        }
    }
}