using UnityEngine;

public class BlockColorGroup : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    private void Awake()
    {
        ColorCollision[] colors = { ColorCollision.Blue, ColorCollision.Green, ColorCollision.Red };
        colors.Shuffle();
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].SetColor(colors[i]);
        }
    }
}