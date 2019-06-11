using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarea_mover : MonoBehaviour
{
    public Transform miTransform; // CLASE 1

    //CLASE 2 y 3
    public Rigidbody miBody;
    public float walkSpeed = 1;
    public float runSpeed = 3;
    public float fuerza = 10;

    public float yaw;
    public float pitch;
    public float xSpeed = 1;
    public Transform miHead;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
        miBody = this.miTransform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        yaw += xSpeed * Input.GetAxis("Mouse X");
        pitch -= xSpeed * Input.GetAxis("Mouse Y");

        if (pitch < -80 )
        {
            pitch = -80;
        }
        if(pitch > 75)
        {
            pitch = 75;
        }
        miHead.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        miTransform.localEulerAngles = new Vector3(0.0f, yaw, 0.0f);


        if (Input.GetKey(KeyCode.W)) // ADELANTE
        {
            /*
             * Conforme se mantenga presionada la "tecla W" se incrementará en el eje Z un valor "deltaTime"
             * a la "posición Z anterior" a una velociddad "speed" para mover al objeto hacia adelante.
             */

            if (Input.GetKey(KeyCode.LeftShift)) //correr
                miTransform.localPosition += miTransform.forward *Time.deltaTime * runSpeed;
            else //caminar
                miTransform.localPosition += miTransform.forward * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKey(KeyCode.S)) // ATRAS
        {
            /*
             * Conforme se mantenga presionada la "tecla S" se Decrementará en el eje Z un valor "deltaTime"
             * a la "posición Z anterior" a una velociddad "speed" para mover al objeto hacia atras.
             */
            miTransform.localPosition -= miTransform.forward * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKey(KeyCode.A)) // IZQUIERDA
        {
            /*
             * Conforme se mantenga presionada la "tecla A" se Decrementará en el eje X un valor "deltaTime"
             * a la "posición X anterior" a una velociddad "speed" para mover al objeto hacia la izquierda.
             */
            miTransform.localPosition -= miTransform.right * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKey(KeyCode.D)) // DERECHA
        {
            /*
             * Conforme se mantenga presionada la "tecla D" se incrementará en el eje X un valor "deltaTime"
             * a la "posición X anterior" a una velociddad "speed" para mover al objeto hacia la derecha.
             */
            miTransform.localPosition += miTransform.right * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            miBody.AddForce(0, fuerza, 0);
        }
    }
}
