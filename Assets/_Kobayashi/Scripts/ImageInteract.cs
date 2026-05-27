using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageInteract : MonoBehaviour
{
    [SerializeField] private float _alpha = 0.3f;
    [SerializeField] private float _duration = 0.2f;
    private Image _img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _img = GetComponent<Image>();
        _img.color = new Color(_img.color.a, _img.color.g, _img.color.b, 0f);
    }

    public void SelectAnimation()
    {
        _img.DOFade(_alpha, _duration);
    }
    public void NotSelectAnimation()
    {
        _img.DOFade(0f, _duration);
    }
}
