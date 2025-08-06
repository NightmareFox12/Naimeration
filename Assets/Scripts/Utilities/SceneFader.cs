using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
  private Image _fadeImage;
  public float fadeDuration = 1f;

  private void Awake()
  {
    _fadeImage = GetComponent<Image>();
  }

  public IEnumerator FadeInCoroutine(float duration)
  {
    Color startColor = new(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 1);
    Color targetColor = new(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 0);
    yield return FadeCoroutine(startColor, targetColor, duration);

    gameObject.SetActive(false);
  }

  public IEnumerator FadeOutCoroutine(float duration)
  {
    Color startColor = new(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 0);
    Color targetColor = new(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 1);
    gameObject.SetActive(true);

    yield return FadeCoroutine(startColor, targetColor, duration);
  }

  private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
  {
    float elapsedTime = 0;
    float elapsedPercentage = 0;

    while (elapsedPercentage < 1)
    {
      elapsedPercentage = elapsedTime / duration;
      _fadeImage.color = Color.Lerp(startColor, targetColor, elapsedPercentage);

      yield return null;
      elapsedTime += Time.deltaTime;
    }

  }
}
