using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance { get; private set; }
    
    [SerializeField] private GameObject coinVFX;
    [SerializeField] private GameObject[] killVFX;
    [SerializeField] private ParticleSystem changeColorVFX;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayCoinVFX(Vector3 position)
    {
        GameObject vfx = Instantiate(coinVFX, position, Quaternion.identity, transform);
        StartCoroutine(DestroyAfterTime(vfx, 2));
    }
    
    public void PlayKillVFX(Vector3 position)
    {
        GameObject vfx = Instantiate(killVFX[Random.Range(0, killVFX.Length)], position, Quaternion.identity, transform);
        StartCoroutine(DestroyAfterTime(vfx, 2));
    }
    
    public void PlayChangeColorVFX(Vector3 position, Color c)
    {
        ParticleSystem vfx = Instantiate(changeColorVFX, position, Quaternion.identity, transform);
        ParticleSystem.MainModule mainModule = vfx.main;
        mainModule.startColor = c;
        StartCoroutine(DestroyAfterTime(vfx.gameObject, 2));
    }

    private static IEnumerator DestroyAfterTime(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(go);
    }
}
