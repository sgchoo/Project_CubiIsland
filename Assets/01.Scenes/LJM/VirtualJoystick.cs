using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능을 지원

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;
    [SerializeField, Range(10f, 150f)]
    private float leverRange;
    
    private Vector2 inputVector;    // 추가
    private bool isInput;    // 추가

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        // var inputDir = eventData.position - rectTransform.anchoredPosition;
        // var clampedDir = inputDir.magnitude < leverRange ? inputDir 
        //     : inputDir.normalized * leverRange;
        // lever.anchoredPosition = clampedDir;

        ControlJoystickLever(eventData);  // 추가
        isInput = true;    // 추가
    }
        
    // 오브젝트를 클릭해서 드래그 하는 도중에 들어오는 이벤트
    // 하지만 클릭을 유지한 상태로 마우스를 멈추면 이벤트가 들어오지 않음    
    public void OnDrag(PointerEventData eventData)
    {
        // var inputDir = eventData.position - rectTransform.anchoredPosition;
        // var clampedDir = inputDir.magnitude < leverRange ? inputDir 
        //     : inputDir.normalized * leverRange;
        // lever.anchoredPosition = clampedDir;
        
        ControlJoystickLever(eventData);    // 추가
        isInput = false;    // 추가
    }
    
    // 추가
    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        var clampedDir = inputDir.magnitude < leverRange ? inputDir 
            : inputDir.normalized * leverRange;
        lever.anchoredPosition = clampedDir;
        inputVector = clampedDir / leverRange;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
    }
}