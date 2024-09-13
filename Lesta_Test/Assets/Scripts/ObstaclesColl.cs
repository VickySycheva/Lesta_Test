using System.Collections.Generic;
using UnityEngine;

public class ObstaclesColl : MonoBehaviour
{
    protected List<Character> characters = new List<Character>();
    
    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out CharacterCollider character))
        {
            characters.Add(character.Character);
        }
    }

    protected void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out CharacterCollider character))
        {
            characters.Remove(character.Character);
        }
    }
}
