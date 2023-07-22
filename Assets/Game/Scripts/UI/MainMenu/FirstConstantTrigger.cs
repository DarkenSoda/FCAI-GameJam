using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstConstantTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("I collided");
        if (other.CompareTag("EndOfTextCollider")) {
            
        }
    }
}
