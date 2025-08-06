using UnityEngine;

public class BallMoveScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private bool isMoving;
    private const float movingForce = 120f;
    [SerializeField] private BallSound _ballSound;
    [SerializeField] private float noBlockHitTimeLimit = 10f; // Час, протягом якого м'яч не повинен залишатися без ударів
    private float _noBlockHitTimer;

    

    private void OnEnable()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _noBlockHitTimer = 0f; // Скидаємо таймер
        PlayerInput.OnClicked += BallActivate;
    }

    private void OnDisable()
    {
        PlayerInput.OnClicked -= BallActivate;
    }

    private void Update()
    {
        // Якщо м'яч рухається, перевіряємо таймер
        if (isMoving)
        {
            _noBlockHitTimer += Time.deltaTime;

            // Якщо таймер перевищує ліміт, знищуємо м'яч
            if (_noBlockHitTimer > noBlockHitTimeLimit)
            {
                Debug.LogWarning("Ball has been idle for too long. Destroying...");
                Destroy(gameObject);
            }
        }
    }

    private void BallActivate()
    {
        if (!isMoving)
        {
            isMoving = true;
            transform.SetParent(null);
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            AddForce();
            _ballSound.PlaySoundAwake();
        }
    }

    public void AddForce(float direction = 0f)
    {
        _rigidbody2D.linearVelocity = Vector2.zero;
        _rigidbody2D.AddForce(new Vector2(direction * (movingForce / 2), movingForce));
    }

    // Викликається з `BallColissions` після успішного удару
    public void ResetNoBlockHitTimer()
    {
        _noBlockHitTimer = 0f; // Скидаємо таймер після удару
    }

    public void StartClone(float direction)
    {
        isMoving = true; 
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        AddForce(direction);
        _ballSound.PlaySoundAwake();
    }
}
