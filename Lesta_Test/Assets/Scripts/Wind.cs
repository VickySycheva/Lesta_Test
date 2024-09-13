using UnityEngine;

public class Wind : ObstaclesColl
{
    [SerializeField] private Vector3 direction;
    private float nextTime;

    void FixedUpdate()
    {
        if(Time.time >= nextTime)
        {
            nextTime = Time.time + 10;
            ChangeDirection();
        }

        foreach (Character character in characters)
        {
            character.Move(direction * Time.fixedDeltaTime);
        }
    }

    void ChangeDirection()
    {
        float dirX = Random.Range(-1f, 1f);
        float dirZ = Random.Range(-1f, 1f);
        direction = new Vector3(dirX, 0 , dirZ);
        direction.Normalize();
    }
}
