using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controla el movimiento básico del jugador en primera persona
public class PlayerMovement : MonoBehaviour {

    public CharacterController characterController;

    // velocidad de movimiento del jugador
    public float speed = 10f;

    // gravedad de jugador
    private float gravity = -9.81f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    Vector3 velocity;

    public float jumpHeight = 3;

    void Start()
    {
    }
    
    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // obtiene la entrada horizontal (A/D o flechas izquierda/derecha)
        float x = Input.GetAxis("Horizontal");

        // obtiene la entrada vertical (W/S o flechas arriba/abajo)
        float z = Input.GetAxis("Vertical");

        // calcula la dirección de movimiento relativa a la orientación del jugador
        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // mueve al jugador teniendo en cuenta la velocidad y el tiempo transcurrido
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

}
