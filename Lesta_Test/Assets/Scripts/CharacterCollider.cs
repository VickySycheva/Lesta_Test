using System;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    public Character Character { get; private set; }

    private Action<Collider> onTriggerEnter;

    public void Init(Character character, Action<Collider> onTriggerEnter)
    {
        Character = character;
        this.onTriggerEnter = onTriggerEnter;
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }
}
