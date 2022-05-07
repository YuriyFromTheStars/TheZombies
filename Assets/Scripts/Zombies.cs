using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    [SerializeField] private GameObject mainPlayer;

    protected RaycastHit2D hitInfoLeftAndRight;
    protected RaycastHit2D hitInfoDown;

    protected Collider2D mainPlayerCollider;
    protected Rigidbody2D rigidbody2DThisEnemy;

    protected bool activationEnemyMovementCoroutine;
    protected bool activationHunting;
    protected bool activationWanders;

    protected float enemyMovementChange;
    protected float hitDistance;
    protected int enemyMovement;
    protected int rayDirection;

    public void Start()
    {
        mainPlayerCollider = mainPlayer.GetComponent<Collider2D>();
    }
    public void EnemyOnTheGround()
    {
        hitInfoDown = Physics2D.Raycast(transform.position, Vector2.down, 1);
    }

    public void Wanders()
    {
        rigidbody2DThisEnemy.velocity = new Vector2(enemyMovement, 0);

        if (enemyMovement < 0) rayDirection = -1;

        if (enemyMovement > 1) rayDirection = 1;


        if (activationEnemyMovementCoroutine)
        {
            StartCoroutine(ZombieMovementCoroutine());
            activationEnemyMovementCoroutine = false;
        }
    }
    public  void EnemyVision()
    {
        hitInfoLeftAndRight = Physics2D.Raycast(transform.position, new Vector2(rayDirection, 0), hitDistance);
        Debug.DrawRay(transform.position, -Vector2.right * hitInfoLeftAndRight.distance, Color.red);
        if (hitInfoLeftAndRight.collider == mainPlayerCollider)
        {
            StartCoroutine(HuntingCoroutine());
            StopCoroutine(HuntingCoroutine());
        }
        else if (hitInfoLeftAndRight.collider != mainPlayerCollider)
        {
            activationHunting = false;
            activationWanders = true;
        }
    }


    public void Hunting()
    {
        transform.position = Vector2.MoveTowards(transform.position, mainPlayer.transform.position, 1.8F * Time.deltaTime);
        
    }

    IEnumerator ZombieMovementCoroutine()
    {
        yield return new WaitForSeconds(enemyMovementChange);
        enemyMovement = Random.Range(-1, 1);
        enemyMovementChange = Random.Range(0, 5);
        activationEnemyMovementCoroutine = true;
    }

    IEnumerator HuntingCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(1.5F, 3));
        activationHunting = true;
        activationWanders = false;
    }
}
