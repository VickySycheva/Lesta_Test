using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float duration;
    [SerializeField] private Vector3 endValue;
    private Material material;
    private Color startColor;
    private Tween tween;

    void Start()
    {
        if(gameObject.GetComponent<Renderer>() != null)
            {
                material = gameObject.GetComponent<Renderer>().material;
                startColor = material.color;
            }

        tween = gameObject.transform.DORotate(endValue, duration).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out CharacterCollider character) && damage != 0)
        {
            character.Character.GetDamage(damage);
        }

        if(material != null)
            material.color = Color.red;
    }

    void OnCollisionExit(Collision other)
    {
        if(material != null)
            material.color = startColor;
    }

    void OnDestroy()
    {
        tween.Kill();
    }
}
