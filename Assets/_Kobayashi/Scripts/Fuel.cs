using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fuel : MonoBehaviour
{
    [Header("-----”’l’²®-----")]
    [SerializeField, Header("‰Î—Íã¸—Ê")] private float _firePower = 10f;
    private Canvas _canvas;
    private GameManager _gameManager;
    private RectTransform _rt;
    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _rt = GetComponent<RectTransform>();
        _canvas = _gameManager.Canvas;
    }

    public void BeginDrag(PointerEventData eventData)
    {
        if(_rt == null)
        {
            _rt = GetComponent<RectTransform>();
        }
        _rt.position = eventData.position;
        Move(eventData);
    }

    public void Drag(PointerEventData eventData)
    {
        Move(eventData);
    }
    private void Move(PointerEventData eventData)
    {
        _rt.anchoredPosition +=
            eventData.delta / _canvas.scaleFactor;
        Debug.Log("ˆÚ“®’†");
    }
    public void EndDrag(PointerEventData eventData)
    {
        GameObject target = eventData.pointerEnter;
        if (target == null) return;

        if (target.TryGetComponent(out FireBox fireBox))
        {
            fireBox.ChangeFire(_firePower);
        }
        else
        {

        }
        _gameManager.FuelObjectPool.ReturnObject(gameObject);
    }
}
