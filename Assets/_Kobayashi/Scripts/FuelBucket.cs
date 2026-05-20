using UnityEngine;
using UnityEngine.EventSystems;

public class FuelBucket : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerClickHandler
{
    private GameManager _gameManager;
    private Fuel _currentFuel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameManager.Instance;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_gameManager.IsCount) return;

        GameObject fuelObj =
           _gameManager.FuelObjectPool.GetObject();

        _currentFuel = fuelObj.GetComponent<Fuel>();
        _currentFuel.BeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_gameManager.IsCount) return;

        _currentFuel?.Drag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_gameManager.IsCount) return;

        _currentFuel?.EndDrag(eventData);

        _currentFuel = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
