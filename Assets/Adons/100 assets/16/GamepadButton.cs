using UnityEngine;
using UnityEngine.EventSystems;

public class GamepadButton :
    MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler
{
    public string buttonName;

    public AndroidGamepad network;

    public void OnPointerDown(
        PointerEventData eventData)
    {
        network.SendButton(
            buttonName,
            true);
    }

    public void OnPointerUp(
        PointerEventData eventData)
    {
        network.SendButton(
            buttonName,
            false);
    }
}