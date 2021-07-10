using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction;

    [SerializeField]
    private float GeyserForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var _collisionGameObjectRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (_collisionGameObjectRigidbody != null)
        {
            _collisionGameObjectRigidbody.AddForce(_direction * GeyserForce, ForceMode2D.Impulse);
        }
    }

}
