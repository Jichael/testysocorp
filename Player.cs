using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public bool IsDead { get; private set; }
    
    public ColorCollision Color { get; private set; }

    [SerializeField] private Animator animator;

    [SerializeField] private float switchLaneSpeed;

    [SerializeField] private float laneDistance;

    [SerializeField] private AnimationCurve rotationCurve;

    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private new Renderer renderer;
    
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private DestroySegment destroySegments;

    private static readonly int SpeedFloat = Animator.StringToHash("Speed");

    private int _laneNb;
    private Vector3 _defaultPos;
    private Transform _transform;
    private bool _isSwitching;
    private Coroutine _switchCo;
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    private void Awake()
    {
        Instance = this;
        _transform = transform;
        _defaultPos = _transform.position;
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat(SpeedFloat, speed);
    }

    public void MoveLeft()
    {
        if (IsDead || _laneNb == -1) return;
        
        _laneNb--;
        if(_isSwitching) StopCoroutine(_switchCo);
        _isSwitching = true;
        _switchCo = StartCoroutine(MoveLaneCo(-1));
    }

    public void MoveRight()
    {
        if (IsDead || _laneNb == 1) return;
        
        _laneNb++;
        if(_isSwitching) StopCoroutine(_switchCo);
        _isSwitching = true;
        _switchCo = StartCoroutine(MoveLaneCo(1));
    }

    private IEnumerator MoveLaneCo(int rotationOrder)
    {
        Vector3 startPos = _transform.position;
        Vector3 endPos = _laneNb switch
        {
            -1 => _defaultPos - Vector3.right * laneDistance,
            1 => _defaultPos + Vector3.right * laneDistance,
            _ => _defaultPos
        };
        
        Vector3 eulers = Vector3.zero;

        float delta = 0;
        while (delta < 1)
        {
            if (IsDead) break;
            delta += Time.deltaTime * switchLaneSpeed;
            _transform.position = Vector3.Lerp(startPos, endPos, delta);
            eulers.y = rotationCurve.Evaluate(delta) * rotationOrder;
            _transform.localEulerAngles = eulers;
            yield return null;
        }

        _isSwitching = false;
    }

    public void Kill()
    {
        IsDead = true;
        rigidBody.AddExplosionForce(1000, _transform.forward - _transform.up * 4, 100);
        gameoverPanel.SetActive(true);
        destroySegments.ShouldDestroy = false;
        GameManager.Instance.EndGame();
    }

    public void SetColor(ColorCollision color)
    {
        Color = color;
        Color c = color.GetColor();
        VFXManager.Instance.PlayChangeColorVFX(_transform.position, c);
        renderer.material.SetColor(ColorID, c);
    }

}

public enum ColorCollision
{
    Red,
    Green,
    Blue,
    White
}