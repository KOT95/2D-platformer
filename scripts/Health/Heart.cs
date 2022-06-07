using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{

    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
        gameObject.SetActive(false);
    }

    public void ToFill(float lerpDuraction)
    {
        StartCoroutine(Filling(0, 1, lerpDuraction, Fill));
    }

    public void ToEmpty(float lerpDuraction)
    {
        StartCoroutine(Filling(1, 0, lerpDuraction, Destroy));
    }

    private IEnumerator Filling(float startValue, float endValue, float duraction, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duraction)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duraction);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }
        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        gameObject.SetActive(false);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
}
