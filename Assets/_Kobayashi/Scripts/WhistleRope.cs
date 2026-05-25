using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class WhistleRope : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private WhistleGauge _gauge;
    [Header("-----数値設定-----")]
    [SerializeField, Header("隠れてる時の始点の位置")] private float _hideStartY;
    [SerializeField, Header("始点の高さ")] private float _startY;
    [SerializeField, Header("終点の高さ")] private float _finishY;
    [SerializeField, Header("演出時間")] private float _duration = 0.3f;

    private GameManager _gameManager;
    private RectTransform _rt;
    private Tween _moveTween;
    void Start()
    {
        _gameManager = GameManager.Instance;
        _rt = GetComponent<RectTransform>();
        _rt.anchoredPosition = new Vector2(_rt.anchoredPosition.x, _hideStartY);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_gameManager.IsCount || _gameManager.IsDead) return;

        if (_gauge.IsFull)
        {
            _moveTween?.Kill();

            _moveTween = _rt.DOAnchorPosY(_finishY, _duration)
                .SetEase(Ease.Linear);

            _gameManager.ChangeWhistleState(true);
            _gameManager.FireBox.SetFire(99);
            Debug.Log("汽笛！！！！！！！！！！！！");
            SoundManager.Instance.PlaySE(SEType.Whistle);
            SoundManager.Instance.PlayBGM(BGMType.Bonus);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void FinishWhistle()
    {
        if (_gameManager.IsCount || _gameManager.IsDead) return;

        _moveTween?.Kill();

        _moveTween = _rt.DOAnchorPosY(_hideStartY, _duration)
            .SetEase(Ease.Linear);
    }

    public void CanStartWhistle()
    {
        if (_gameManager.IsCount || _gameManager.IsDead) return;
        _moveTween?.Kill();

        _moveTween = _rt.DOAnchorPosY(_startY, _duration)
            .SetEase(Ease.Linear);
    }
    public void OnDrag(PointerEventData eventData)
    {

    }
}
