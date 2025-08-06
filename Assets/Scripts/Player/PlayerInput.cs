using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMove playerMove;
    public static event Action OnClicked;
       private void Awake()
       {
         playerMove = FindAnyObjectByType<PlayerMove>();
                if (playerMove == null)
                {
                    Debug.LogError("PlayerMove not found in the scene.");
                }
            Application.targetFrameRate = 90;
        }
        
    

    private void Update()
    {
#if UNITY_EDITOR
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float playerPositionX = playerMove.transform.position.x;
        playerMove.MoveToPosition(playerPositionX + horizontalInput * Time.deltaTime * 10f);
        if (Input.GetKeyDown(KeyCode.Backspace) )
        {
            OnClicked?.Invoke();
        }
#endif

        GetTouchInput();

    }

    private void GetTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.tapCount > 1)
             {
               OnClicked?.Invoke();
             }
            // Перетворюємо позицію дотику на позицію в ігровому світі
             Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f)); // 10f для віддалення камери

            // Викликаємо метод для переміщення платформи в нову позицію
            playerMove.MoveToPosition(worldPosition.x);
        }
    }
}
