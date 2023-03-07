using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameEvents.Instance.PlayerDied();
        }
        else if (collision.CompareTag("Cupcake"))
        {
            GameEvents.Instance.PickedUpCupcake(collision.gameObject);
        }
        else if (collision.CompareTag("Finish"))
        {
            GameEvents.Instance.FinishLevel();
        }
        else if (collision.CompareTag("GodCake"))
        {
            GameEvents.Instance.FinishedGame();
        }
    }
}
