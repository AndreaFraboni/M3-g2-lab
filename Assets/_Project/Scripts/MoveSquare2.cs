using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _speed       = 5.0f;
    [SerializeField] private float _maxDistance = 5.0f;

    private Vector2 startPosition;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        if (_rb == null) // se _rb non è definito lo cerchiamo e lo assegnamo a _rb
        {
            _rb = GetComponent<Rigidbody2D>(); 
        }

        startPosition = _rb.position; // salvo la posizione inziale del quadrato
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement(); // controlla la pressione dei tasti determinando la direzione del movimento
        CheckPosition(); // controllo la posizione
    }

    private void FixedUpdate()
    {
        MoveSquare(); // eseguo il movimento in FixedUpdate per gestire il movimento con RigidBody
    }

    void MoveSquare()
    {
        _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));
    }

    void CheckPosition()
    {
        Vector3 currentPosition;
        currentPosition = _rb.position;

        float distanceValue = Vector2.Distance( currentPosition, startPosition);
        if (distanceValue > _maxDistance)
        {
            _rb.position = startPosition;
        }
    
    }

    void CheckMovement() // controlla l'Input da tastiera WASD - Tasti freccia .....
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        direction = new Vector3(h, v);

        float sqrLenght = direction.sqrMagnitude;
        if (sqrLenght > 1)
        {
            direction = direction / Mathf.Sqrt(sqrLenght);
        }
    }

}
