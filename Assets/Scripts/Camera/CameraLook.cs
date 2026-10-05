using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controla la rotación de la cámara en primera persona
/// mediante el movimiento del mouse
/// </summary>
public class CameraLook : MonoBehaviour {

    // sensibilidad del mouse
    public float mouseSensitivity = 80f;

    /// <summary>
    /// referencia al cuerpo deljugador para rotarlo horizontalmente
    /// </summary>
    public Transform playerBody;

    /// <summary>
    /// rotación acululada en el eje x (arriba/abajo)
    /// </summary>
    float xRotation = 0f;

    /// <summary>
    /// se ejecuta una vez al iniciar el juego.
    /// bloquea el cursor en el centro de la pantalla
    /// </summary>
    void Start()
    {
        xRotation = 0f;

        transform.localRotation = Quaternion.identity;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    /// <summary>
    /// se ejecuta cada frame y procesa el movimiento
    /// de la cámara con el mouse
    /// </summary>
    void Update()
    {

        if (Time.frameCount < 5)
        {
            return;
        }
        
        // obtiene el movimiento horizontal dle mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float rawY = Input.GetAxis("Mouse Y");
        // Debug.Log("Raw MouseY: " + rawY);

        float mouseY = rawY * mouseSensitivity * Time.deltaTime;
        // obtiene el movimiento vertical del mouse
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // acumula la rotación vertical
        xRotation += mouseY; 

        // límita la vista para evitar giros imposibles
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // aplica la rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        // rota horizontalmente el cuerpo del jugador
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
