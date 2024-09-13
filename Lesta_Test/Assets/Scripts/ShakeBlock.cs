using DG.Tweening;
using UnityEngine;

public class ShakeBlock : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float duration;
    [SerializeField] private float strength;
    [SerializeField] private int vibrato;
    [SerializeField] private float randomness;
    [SerializeField] private Gradient gradient;
    [SerializeField]private bool shakePos;
    private Tween shake;

    private bool isActive = false;
    private Sequence sequence;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(isActive)
        {
            return;
        }
        DoShake();
    }

    void DoShake()
    {
        isActive = true;
        sequence = DOTween.Sequence();
        if(!shakePos)
        {
            shake = gameObject.transform.DOShakeRotation(duration, strength, vibrato, randomness);
        }
        else
        {
            shake = gameObject.transform.DOShakePosition(duration, strength, vibrato, randomness);
        }
        
        sequence.Append(shake)
                .Join(material.DOGradientColor(gradient, duration));
        
        sequence.OnComplete(() =>  gameObject.SetActive(false));        
    }

    void OnDestroy()
    {
        if (sequence != null) sequence.Kill();
    }
}