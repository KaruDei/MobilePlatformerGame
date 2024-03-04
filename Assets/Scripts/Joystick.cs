using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform _marker;
    private RectTransform _joystick;
    private Vector2 _startPos;
    private Vector2 _direction;
    private float _joystickRadius = 200f;

    private void Awake()
    {
        _joystick = GetComponent<RectTransform>();
        _marker = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount > 0)
            _startPos = Input.GetTouch(0).position;
        else
            _startPos = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset = Vector2.zero;
        if (Input.touchCount > 0)
            offset = Input.GetTouch(0).position - _startPos;
        else
            offset = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - _startPos;

        offset = Vector2.ClampMagnitude(offset, _joystickRadius);

        _marker.anchoredPosition = offset;

        _direction = offset.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _marker.anchoredPosition = Vector2.zero;
        _direction = Vector2.zero;
    }

    public Vector2 GetDirection()
    {
        return _direction;
    }
}
