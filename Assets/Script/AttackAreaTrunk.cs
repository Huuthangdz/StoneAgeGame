using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaTrunk : MonoBehaviour
{
    [SerializeField] private Transform AttackArea;
    [SerializeField] private TrunkEnemi TrunkEnemi;

    private float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer = Time.deltaTime;
            StartCoroutine(TrunkEnemi.shoot());
            timer = 0;
        }
    }
}
