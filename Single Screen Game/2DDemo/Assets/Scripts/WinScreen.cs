using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.Win();
    }
}
