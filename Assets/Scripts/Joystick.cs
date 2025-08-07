using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RectTransform background;
    public RectTransform handle;
    public float handleRange = 50f;
    public float Horizontal => inputVector.x;


    private Vector2 inputVector;

    void Awake()
    {
        //android verification
        // #if !UNITY_ANDROID
        //     gameObject.SetActive(false);
        // #endif
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, eventData.position, eventData.pressEventCamera, out Vector2 pos);

        pos = Vector2.ClampMagnitude(pos, handleRange);
        handle.anchoredPosition = pos;
        inputVector = pos / handleRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
