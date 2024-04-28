using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedEnemy = 1f;
    Rigidbody2D enemyRigidbody;
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        enemyRigidbody.velocity = new Vector2(moveSpeedEnemy, 0f);
    }

    void OnTriggerExit2D(Collider2D other) {
        moveSpeedEnemy = -moveSpeedEnemy;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing(){
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
    }
}
