using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BlankEvent gameOverEvent;
    [SerializeField] private Animator[] uIsGameOver;

    private void Update()
    {
        gameOverEvent.Listeners += GameOver;
    }

    private void GameOver()
    {
        int count = uIsGameOver.Length;
        for (int i = 0; i < count; i++)
        {
            uIsGameOver[i].SetBool("GameOver", true);
        }
    }
}
