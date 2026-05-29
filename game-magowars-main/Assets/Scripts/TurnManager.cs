using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public PlayerController playerController;
    public EnemyAI enemyAI;

    public float delayBeforeEnemyTurn = 2f;
    public float delayBeforePlayerTurn = 2f;

    public bool isPlayerTurn = true;

    void Start()
    {
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        playerController.canShoot = true;

        Debug.Log("Turno do jogador.");
    }

    public void EndPlayerTurn()
    {
        if (!isPlayerTurn) return;

        isPlayerTurn = false;
        playerController.canShoot = false;

        Debug.Log("Fim do turno do jogador.");

        StartCoroutine(EnemyTurnRoutine());
    }

    IEnumerator EnemyTurnRoutine()
    {
        yield return new WaitForSeconds(delayBeforeEnemyTurn);

        Debug.Log("Turno do inimigo.");

        enemyAI.ShootAtPlayer();

        yield return new WaitForSeconds(delayBeforePlayerTurn);

        StartPlayerTurn();
    }
}