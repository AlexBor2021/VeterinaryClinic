using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingClient : MonoBehaviour
{
    [SerializeField] private GameObject _looding;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private float _timeRecovery;

    private Image _image;
    private Coroutine _loodingTransfer;
    private float _startValue;
    private float _endValue;
    private bool _isActiveBackGround;

    public event UnityAction LoadedBarClient;

    private void OnEnable()
    {
        _isActiveBackGround = false;
        OnBackground(_isActiveBackGround);
        _startValue = 0;
        _endValue = 1;
        _image = _looding.GetComponent<Image>();
        _image.fillAmount = 0;
    }

    private IEnumerator LoodingTransfer(float duration, float startValue, float endValue)
    {
        float elapsedtime = 0;

        while (elapsedtime < duration)
        {
            var nextValue = Mathf.Lerp(startValue, endValue, elapsedtime/duration);
            _image.fillAmount = nextValue;
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        StopCoroutine(_loodingTransfer);
        LoadedBarClient?.Invoke();
        ZeroLoading();
    }

    public void StartTransfer()
    {
        _isActiveBackGround = true;
        OnBackground(_isActiveBackGround);
        _loodingTransfer = StartCoroutine(LoodingTransfer(_timeRecovery, _startValue, _endValue));
    }

    public void StopTransfer()
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
        _isActiveBackGround = false;
        OnBackground(_isActiveBackGround);
        _startValue = 0;
        _endValue = 1;
        _image.fillAmount = 0;
    }
}
