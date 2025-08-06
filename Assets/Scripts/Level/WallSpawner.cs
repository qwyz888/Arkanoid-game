using UnityEngine;
using System.Collections; // Підключаємо для IEnumerator

public class WallSpawner : MonoBehaviour
{
    public GameObject WallPrefab;  

    public float Margin = 0.15f; // Запас у пікселях всередину меж камери

    private Camera componentCamera;

    private void Start()
    {
        componentCamera = Camera.main;

        if (WallPrefab == null )
        {
            Debug.LogError("One or more wall prefabs are not assigned!");
            return;
        }

        StartCoroutine(DelayedSpawnWalls());
    }

    private IEnumerator DelayedSpawnWalls()
    {
        yield return new WaitForEndOfFrame(); // Чекаємо завершення першого кадру
        SpawnWalls(); // Тепер розрахунок буде враховувати актуальні розміри камери
    }

    private void SpawnWalls()
    {
        // Отримуємо розміри камери
        float screenHeight = componentCamera.orthographicSize * 2f; // Висота камери
        float screenWidth = screenHeight * componentCamera.aspect;  // Ширина камери

        // Позиції для стін з урахуванням запасу
        Vector3 leftWallPosition = new Vector3(-screenWidth / 2f + Margin, 0f, 0f);  // Ліва стіна
        Vector3 rightWallPosition = new Vector3(screenWidth / 2f - Margin, 0f, 0f);  // Права стіна
        Vector3 topWallPosition = new Vector3(0f, screenHeight / 2f - Margin, 0f);   // Верхня стіна

        // Обертання для вертикальних стін
        Quaternion verticalRotation = Quaternion.Euler(0f, 0f, 90f);

        // Створюємо стіни
        Instantiate(WallPrefab, leftWallPosition, verticalRotation);  // Ліва стіна
        Instantiate(WallPrefab, rightWallPosition, verticalRotation); // Права стіна
        Instantiate(WallPrefab, topWallPosition, Quaternion.identity); // Верхня стіна
    }
}
