using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class TransparentObject : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _transparencyValue = 0.75f;
    [SerializeField] private float _transparecencyFadeTime = .4f;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            StartCoroutine(FadeTree(_spriteRenderer, _transparecencyFadeTime, _spriteRenderer.color.a, _transparencyValue));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            StartCoroutine(FadeTree(_spriteRenderer, _transparecencyFadeTime, _spriteRenderer.color.a, 1f));
        }
    }

    private IEnumerator FadeTree(SpriteRenderer _spriteTransparency, float _fadeTime, float _startValue, float _targetTransparency)
    {
        float _timeElapsed = 0;
        while (_timeElapsed < _fadeTime)
        {
            _timeElapsed += Time.deltaTime;
            float _newTransparency = Mathf.Lerp(_startValue, _targetTransparency, _timeElapsed / _fadeTime);
            _spriteTransparency.color = new Color(_spriteTransparency.color.r, _spriteTransparency.color.g, _spriteTransparency.color.b, _newTransparency);
            yield return null;
        }
        
    }


}
