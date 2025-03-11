using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;
    public float verticalMoveDistance = 1f;
    public float verticalMoveTime = 1f;

    private Transform player;
    private Vector3 initialPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        initialPosition = transform.position;
        StartCoroutine(MoveUpDown());
        InvokeRepeating("Shoot", 1f, fireRate);
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    IEnumerator MoveUpDown()
    {
        while (true)
        {
            Vector3 upPosition = initialPosition + Vector3.up * verticalMoveDistance;
            Vector3 downPosition = initialPosition - Vector3.up * verticalMoveDistance;
            yield return MoveToPosition(upPosition);
            yield return MoveToPosition(downPosition);
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < verticalMoveTime)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / verticalMoveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    void Shoot()
    {
        if (player == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        TrailRenderer trail = bullet.GetComponent<TrailRenderer>();
        if (trail != null)
        {
            trail.enabled = true;
        }
    }
}
