using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controla el movimiento básico del jugador en primera persona
public class PlayerMovement : MonoBehaviour {

    public CharacterController characterController;

    // velocidad de movimiento del jugador
    public float speed = 10f;

    private float gravity = -9.81f;

    Vector3 velocity;

    void Start()
    {
    }
    
    void Update() {

        // obtiene la entrada horizontal (A/D o flechas izquierda/derecha)
        float x = Input.GetAxis("Horizontal");

        // obtiene la entrada vertical (W/S o flechas arriba/abajo)
        float z = Input.GetAxis("Vertical");

        // calcula la dirección de movimiento relativa a la orientación del jugador
        Vector3 move = transform.right * x + transform.forward * z;

        // mueve al jugador teniendo en cuenta la velocidad y el tiempo transcurrido
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

}
