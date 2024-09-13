using DG.Tweening;
using UnityEngine;

public class Bomb : ObstaclesColl
{
    [SerializeField] private Color orangeColor;
    private Material material;
    private Color startColor;
    private float damage = 20;
    private bool isActive;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        startColor = material.color;
    }

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        
        if (!isActive)
        {
            Explode();
        }

    }

    async void Explode()
    {
        isActive = true;

        material.color = orangeColor;

        await material.DOColor(Color.red, 0.2f)
                        .SetDelay(1)
                        .AsyncWaitForCompletion();

        if (characters.Count > 0)
        {
            foreach (Character character in characters)
                    character.GetDamage(damage);
        }

        await material.DOColor(startColor, 5)
                        .AsyncWaitForCompletion();
        isActive = false;

        if (characters.Count > 0)
                Explode();
    }
}
