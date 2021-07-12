using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if (p != Player.Instance) return;
        
        ScoreManager.Instance.ChangeScore(1);
        VFXManager.Instance.PlayCoinVFX(transform.position);
        Destroy(gameObject);
    }
}
