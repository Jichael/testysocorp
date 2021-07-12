using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] private Renderer[] renderers;

    private ColorCollision _color = ColorCollision.White;
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != Player.Instance) return;
        
        if (player.Color == _color)
        {
            gameObject.SetActive(false);
            ScoreManager.Instance.ChangeScore(1);
        }
        else
        {
            VFXManager.Instance.PlayKillVFX(transform.position);
            player.Kill();
        }
    }

    public void SetColor(ColorCollision c)
    {
        _color = c;
        Color color = c.GetColor();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.SetColor(ColorID, color);
        }
    }
}