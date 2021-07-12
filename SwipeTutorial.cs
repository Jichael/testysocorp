using System.Collections;
using UnityEngine;

public class SwipeTutorial : MonoBehaviour
{

    [SerializeField] private float animationSpeed;
    [SerializeField] private float translationOffset;

    [SerializeField] private GameObject score;
    
    private void Awake()
    {
        StartCoroutine(AnimationCo());
    }

    private IEnumerator AnimationCo()
    {
        yield return new WaitForSeconds(0.5f);
        
        Transform t = transform;
        float delta = 0;
        Vector2 position = t.position;
        float startPos = position.x;
        float endPos = startPos - translationOffset;

        while (delta < 1)
        {
            delta += Time.deltaTime * animationSpeed;
            position.x = Mathf.Lerp(startPos, endPos, delta);
            t.position = position;
            yield return null;
        }

        delta = 0;
        startPos = endPos;
        endPos += translationOffset;
        
        while (delta < 1)
        {
            delta += Time.deltaTime * animationSpeed;
            position.x = Mathf.Lerp(startPos, endPos, delta);
            t.position = position;
            yield return null;
        }
        
        yield return new WaitForSeconds(0.3f);

        delta = 0;
        startPos = endPos;
        endPos += translationOffset;
        
        while (delta < 1)
        {
            delta += Time.deltaTime * animationSpeed;
            position.x = Mathf.Lerp(startPos, endPos, delta);
            t.position = position;
            yield return null;
        }

        delta = 0;
        startPos = endPos;
        endPos -= translationOffset;
        
        while (delta < 1)
        {
            delta += Time.deltaTime * animationSpeed;
            position.x = Mathf.Lerp(startPos, endPos, delta);
            t.position = position;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        
        score.SetActive(true);
        Destroy(gameObject);
    }
}
