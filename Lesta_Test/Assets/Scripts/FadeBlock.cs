using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class FadeBlock : MonoBehaviour 
{
    [SerializeField] private float value;
    [SerializeField] private float duration;
    [SerializeField] private Material material;
    
    private Tween tween;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }

    void OnCollisionEnter(Collision other)
    {
        DoFadeBlock();
    }

    void DoFadeBlock()
    {
        tween = material.DOFade(value, duration)
                .OnComplete(() => gameObject.SetActive(false));
    }

    void OnDestroy()
    {
        if (tween != null) tween.Kill();
    }
}
