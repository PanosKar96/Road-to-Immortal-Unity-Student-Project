using UnityEngine;
using UnityEngine.EventSystems;

public class QuickButtonDepth : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
        
    // Visual target (usually the Button's RectTransform). If null, uses this object.
   [SerializeField] private RectTransform target;

   //Press effect settings
   [SerializeField] private float pressedScale = 0.94f;
   [SerializeField] private Vector2 pressedOffset = new Vector2(0f, -2f);

   private RectTransform rt;
   private Vector3 baseScale;
   private Vector2 basePos;

   private void Awake()
    {
        rt = (target != null) ? target : GetComponent<RectTransform>();
        baseScale = rt.localScale;
        basePos = rt.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rt.localScale = baseScale * pressedScale;
        rt.anchoredPosition = basePos + pressedOffset;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rt.localScale = baseScale;
        rt.anchoredPosition = basePos;
    }
}
