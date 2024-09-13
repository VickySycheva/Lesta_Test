using UnityEngine;
using DG.Tweening;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] private Vector3 pointToMove;
    [SerializeField] private float duration;
    private Tween tween;

    void Start()
    {
        tween = gameObject.transform.DOLocalMove(pointToMove, duration).SetLoops(-1, LoopType.Yoyo);
    }

    void OnDestroy()
    {
        tween.Kill();
    }
}
