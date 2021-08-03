using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private GameObject popEffect;

    private void Start()
    {
        Destroy(gameObject, 5f);

    }
    private void OnMouseDown()
    {
        Instantiate(popEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
