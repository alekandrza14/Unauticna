using UnityEngine;
using UnityEngine.EventSystems;
public class GamepadButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string buttonName;
    public AndroidGamepad network;
    public void OnPointerDown(PointerEventData data) { if (network != null) network.SendButton(buttonName, true); }
    public void OnPointerUp(PointerEventData data) { if (network != null) network.SendButton(buttonName, false); }
    void OnDisable() { if (network != null) network.SendButton(buttonName, false); }
}
