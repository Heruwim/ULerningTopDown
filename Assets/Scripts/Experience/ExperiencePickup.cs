using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    [SerializeField] private int _amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController> (out var PlayerController))
        {
            PlayerController.AddExperience(_amount);
            Destroy(gameObject);
        }
    }
}
