using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnMargin = 1f;

    private Camera mainCamera;
    private float timer;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || mainCamera == null) return;

        Vector3 spawnPosition = GetRandomOffscreenPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomOffscreenPosition()
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        Vector3 camPos = mainCamera.transform.position;

        int edge = Random.Range(0, 4);
        float x;
        float y;

        switch (edge)
        {
            case 0: // 위
                x = Random.Range(-camWidth, camWidth);
                y = camHeight + spawnMargin;
                break;
            case 1: // 아래
                x = Random.Range(-camWidth, camWidth);
                y = -camHeight - spawnMargin;
                break;
            case 2: // 왼쪽
                x = -camWidth - spawnMargin;
                y = Random.Range(-camHeight, camHeight);
                break;
            default: // 오른쪽
                x = camWidth + spawnMargin;
                y = Random.Range(-camHeight, camHeight);
                break;
        }

        return camPos + new Vector3(x, y, 0f);
    }
}
