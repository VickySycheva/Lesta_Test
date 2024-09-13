using UnityEngine;

public class Trampoline : ObstaclesColl
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float delay;
    private float nextTime;

    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + delay;
            foreach (Character character in characters)
            {
                character.AddJumpForce(jumpForce);
            }
        }
        
    }
}
