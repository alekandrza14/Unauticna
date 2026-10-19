using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    public AndroidGamepad network;
    RectTransform rect;
    void Awake() { rect = transform as RectTransform; }
    public void OnPointerDown(PointerEventData data) { OnDrag(data); }
    public void OnDrag(PointerEventData data)
    {
        if (rect == null) return;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, data.position, data.pressEventCamera, out var pos)) return;
        Vector2 center = rect.rect.center;
        var input = Vector2.ClampMagnitude(new Vector2((pos.x - center.x) / Mathf.Max(1, rect.rect.width * 0.5f),
            (pos.y - center.y) / Mathf.Max(1, rect.rect.height * 0.5f)), 1);
        if (handle != null) handle.anchoredPosition = input * 100;
        if (network != null) network.SendJoystick(input.x, input.y);
    }
    public void OnPointerUp(PointerEventData data) { Release(); }
    void Release() { if (handle != null) handle.anchoredPosition = Vector2.zero; if (network != null) network.SendJoystick(0, 0); }
    void OnDisable() { Release(); }
}
