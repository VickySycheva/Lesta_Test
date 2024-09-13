using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Action<float> OnHealthUpdate;

    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private CharacterCollider characterCollider;

    private Action OnStart;
    private Action<bool> OnEndGame;

    private float health = 100;

    public void Init(Action onStart, Action<bool> onGameEnd)
    {
        OnStart = onStart;
        OnEndGame = onGameEnd;

        thirdPersonController.Init();
        characterCollider.Init(this, OnTriggerEnterFunc);

        OnHealthUpdate.Invoke(health);
    }

    public void AddJumpForce(float jumpForce)
    {
        thirdPersonController.AddJumpForce(jumpForce);
    }

    public void Move(Vector3 vector3)
    {
        thirdPersonController.CharacterController.Move(vector3);
    }

    public void GetDamage (float damage)
    {
        health -= damage;
        OnHealthUpdate.Invoke(health);
        if (health <= 0)
        {
            OnEndGame.Invoke(false);
        }
    }

    private void OnTriggerEnterFunc(Collider other)
    {
        switch (other.tag)
        {
            case "Start":
                OnStart.Invoke();
                break;
            case "Finish":
                OnEndGame.Invoke(true);
                break;
            case "Bottom":
                OnEndGame.Invoke(false);
                break;
        }
    }
}
