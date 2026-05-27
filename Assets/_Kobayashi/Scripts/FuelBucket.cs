using UnityEngine;
using UnityEngine.EventSystems;

public class FuelBucket : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerClickHandler
{
    [SerializeField] private ImageInteract _ii;
    private GameManager _gameManager;
    private Fuel _currentFuel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameManager.Instance;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_gameManager.IsCount || _gameManager.IsDead) return;
        SoundManager.Instance.PlaySE(SEType.Grab);
        GameObject fuelObj =
           _gameManager.FuelObjectPool.GetObject();

        _currentFuel = fuelObj.GetComponent<Fuel>();
        _currentFuel.BeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_gameManager.IsCount || _gameManager.IsDead) return;

        _currentFuel?.Drag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_gameManager.IsCount || _gameManager.IsDead) return;

        _currentFuel?.EndDrag(eventData);

        _currentFuel = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _ii.SelectAnimation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _ii.NotSelectAnimation();
    }
}
