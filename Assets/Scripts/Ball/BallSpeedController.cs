using UnityEngine;

public class BallSpeedController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private const float MIN_SPEED = 0.5f;
    private const float MAX_SPEED = 3.5f;
    private const int WAIT_FRAME = 30;

    private void Update()
    {
       if(_rigidbody2D.linearVelocity.magnitude != 0)
        {
            if(Time.frameCount % WAIT_FRAME == 0)
            {
                if(_rigidbody2D.linearVelocity.magnitude < MIN_SPEED || 
                    _rigidbody2D.linearVelocity.magnitude > MAX_SPEED)
                {
                    float SpeedCorrect = MAX_SPEED / _rigidbody2D.linearVelocity.magnitude;
                    _rigidbody2D.linearVelocity *= SpeedCorrect;
                }
            }
        } 
    }
}
