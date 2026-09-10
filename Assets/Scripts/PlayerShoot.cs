using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireInterval = 1f;
    public float bulletSpeed = 10f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            timer = 0f;
            TryShoot();
        }
    }

    private void TryShoot()
    {
        Transform nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null) return;

        Vector2 direction = (nearestEnemy.position - transform.position).normalized;

        GameObject bulletObject = BulletPool.Instance.GetBullet();
        bulletObject.transform.position = transform.position;
        bulletObject.transform.rotation = Quaternion.identity;

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.speed = bulletSpeed;
        bullet.SetDirection(direction);
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform nearest = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearest = enemy.transform;
            }
        }

        return nearest;
    }
}
