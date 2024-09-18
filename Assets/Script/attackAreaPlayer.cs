using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackAreaPlayer : MonoBehaviour
{
    public float Damage;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ( collider.gameObject.tag == "Enemi")
        {
            collider.GetComponent<CharacterEnemi>().takeDame(Damage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
