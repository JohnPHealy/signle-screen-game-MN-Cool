using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Collider2D enemyCheck;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private GameManager manager;
    [SerializeField] private int scoreToGive = 10;

    void Update()
    {
        transform.position += (Vector3.left * Time.deltaTime) * moveSpeed;
    }

    public void FixedUpdate()
    {
        if (enemyCheck.IsTouchingLayers(enemyLayers))
        {
            manager.AddScore(scoreToGive);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            manager.AddScore(scoreToGive);
        }
    }
}