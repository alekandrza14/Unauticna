using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick :
    MonoBehaviour,
    IDragHandler,
    IPointerUpHandler,
    IPointerDownHandler
{
    public RectTransform handle;

    public AndroidGamepad network;

    private Vector2 input;

    public void OnPointerDown(
        PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(
        PointerEventData eventData)
    {
        RectTransform rect =
            transform as RectTransform;

        Vector2 pos;

        RectTransformUtility.
        ScreenPointToLocalPointInRectangle(
            rect,
            eventData.position,
            eventData.pressEventCamera,
            out pos);

        pos.x /= rect.sizeDelta.x;
        pos.y /= rect.sizeDelta.y;

        input = new Vector2(
            pos.x * 2,
            pos.y * 2);

        input = Vector2.ClampMagnitude(
            input,
            1);

        handle.anchoredPosition =
            new Vector2(
                input.x * 100,
                input.y * 100);

      //  network.SendJoystick(
    //        input.x,
      //      input.y);
    }
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.02f) // 50 FPS отправка
        {
            timer = 0;
            network.SendJoystick(input.x, input.y);
        }
    }
    public void OnPointerUp(
        PointerEventData eventData)
    {
        input = Vector2.zero;

        handle.anchoredPosition =
            Vector2.zero;

        network.SendJoystick(0,0);
    }
}