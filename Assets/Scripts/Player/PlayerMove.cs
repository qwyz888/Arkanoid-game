using UnityEngine;
using System.Collections; // Для IEnumerator

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Camera _mainCamera;

    [SerializeField]
    private float wallPadding = 0.5f; // Відстань між платформою і стінами (налаштовується)

    private float _screenLimitX; // Максимальна межа переміщення платформи по X

    private void Awake()
    {
        
        _mainCamera = Camera.main;

        if (_mainCamera == null)
        {
            Debug.LogError("Main Camera is not found! Ensure there is a camera tagged as 'MainCamera' in the scene.");
        }

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            _rigidbody2D = player.GetComponent<Rigidbody2D>();
            if (_rigidbody2D == null)
            {
                Debug.LogError("Rigidbody2D not found on the Player object!");
            }
            _spriteRenderer = player.GetComponent<SpriteRenderer>();
            if (_spriteRenderer == null)
            {
                Debug.LogError("_spriteRenderer not found on the Player object!");
            }

        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found!");
        }
    }

    private void Start()
    {
        StartCoroutine(DelayedCalculateScreenLimits());
    }

    private IEnumerator DelayedCalculateScreenLimits()
    {
        yield return new WaitForEndOfFrame(); // Чекаємо завершення першого кадру
        CalculateScreenLimits(); // Розраховуємо межі після налаштування камери
    }

      public void CalculateScreenLimits()
    {
        // Отримуємо ширину видимої частини екрану камери
        float screenWidth = _mainCamera.orthographicSize * _mainCamera.aspect;

        // Визначаємо межі з урахуванням ширини платформи та відступу
        _screenLimitX = screenWidth - (_spriteRenderer.size.x / 2) - wallPadding;
    }

    public void MoveToPosition(float targetX)
    {
        // Обмежуємо позицію платформи по осі X в межах екрану з урахуванням відступу
        targetX = Mathf.Clamp(targetX, -_screenLimitX, _screenLimitX);

        // Переміщуємо платформу безпосередньо в позицію пальця
        _rigidbody2D.MovePosition(new Vector2(targetX, _rigidbody2D.position.y));
    }

    public void ResetPosition()
    {
        _rigidbody2D.position = new Vector2(0f, _rigidbody2D.position.y);
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    }
}
