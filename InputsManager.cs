using UnityEngine;
using UnityEngine.InputSystem;

public class InputsManager : MonoBehaviour
{
    [SerializeField] private InputAction primaryContactAction;
    [SerializeField] private InputAction primaryPositionAction;
    
    private Vector2 _startPosition;
    private double _startTime;
    
    private const double MAX_SWIPE_TIME = 1;
    private const float MIN_SWIPE_DISTANCE = 30;

    private void OnEnable()
    {
        primaryContactAction.Enable();
        primaryContactAction.started += OnStartTouch;
        primaryContactAction.canceled += OnEndTouch;
        
        primaryPositionAction.Enable();
    }

    private void OnDisable()
    {
        primaryContactAction.Disable();
        primaryContactAction.performed -= OnStartTouch;
        primaryContactAction.canceled -= OnEndTouch;
        
        primaryPositionAction.Disable();
    }

    private void OnStartTouch(InputAction.CallbackContext ctx)
    {
        _startPosition = primaryPositionAction.ReadValue<Vector2>();
        _startTime = ctx.time;
    }
    
    private void OnEndTouch(InputAction.CallbackContext ctx)
    {
        Vector2 endPosition = primaryPositionAction.ReadValue<Vector2>();
        double endTime = ctx.time;
        
        if (endTime - _startTime > MAX_SWIPE_TIME) return;

        Vector2 direction = endPosition - _startPosition;

        if (direction.x < -MIN_SWIPE_DISTANCE) Player.Instance.MoveLeft();
        else if (direction.x > MIN_SWIPE_DISTANCE) Player.Instance.MoveRight();
    }
}