using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingBox : MonoBehaviour
{
    [SerializeField] private GameObject _looding;
    [SerializeField] private float _timeRecovery;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private GameObject _arrow;

    private Image _image;
    private float _startValue;
    private float _endValue;
    private Coroutine _loodingTransfer;
    private bool _onBackGround;

    public event UnityAction LoadedBarBox;

    private void OnEnable()
    {
        _onBackGround = false;
        OnBackground(_onBackGround);
        _startValue = 0;
        _endValue = 1;
        _image = _looding.GetComponent<Image>();
        _image.fillAmount = 0;
    }


    private IEnumerator LoodingCreat(float duration, float startValue, float endValue)
    {
        float elapsedtime = 0;

        while (elapsedtime < duration)
        {
            var nextValue = Mathf.Lerp(startValue, endValue, elapsedtime / duration);
            _image.fillAmount = nextValue;
            elapsedtime += Time.deltaTime;
            yield return null;
        }

        StopCoroutine(_loodingTransfer);
        LoadedBarBox?.Invoke();
        ZeroLoading();
    }

    public void StartCreat()
    {
        _onBackGround = true;
        _arrow.SetActive(false);
        OnBackground(_onBackGround);
        _loodingTransfer = StartCoroutine(LoodingCreat(_timeRecovery, _startValue, _endValue));
    }

    public void StopCreat()
    {
        StopCoroutine(_loodingTransfer);
        ZeroLoading();
    }

    private void OnBackground(bool _onBackGround)
    {
        _backGround.SetActive(_onBackGround);
    }

    private void ZeroLoading()
    {
        _onBackGround = false;
        OnBackground(_onBackGround);
        _startValue = 0;
        _endValue = 1;
        _image.fillAmount = 0;
    }
}
