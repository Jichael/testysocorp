using UnityEngine;
using Random = UnityEngine.Random;

public class ColorLine : MonoBehaviour
{

    private ColorCollision _color;

    [SerializeField] private new Renderer renderer;
    private static readonly int MainColor = Shader.PropertyToID("_Color");

    private void Awake()
    {
        ColorCollision[] colors = { ColorCollision.Blue, ColorCollision.Green, ColorCollision.Red };
        _color = colors[Random.Range(0, colors.Length)];
        renderer.material.SetColor(MainColor, _color.GetColor());
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != Player.Instance) return;
        
        player.SetColor(_color);
    }
}
