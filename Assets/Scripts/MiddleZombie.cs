using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleZombie : Zombies
{

    
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        activationHunting = false;
        activationWanders = true;
        activationEnemyMovementCoroutine = true;
        hitDistance = 15F;
        rayDirection = 0;
        enemyMovementChange = 0;
        enemyMovement = 0;
        rigidbody2DThisEnemy = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (activationWanders) Wanders();
        if (activationHunting) Hunting();
        EnemyVision();
        EnemyOnTheGround();
    }



}
