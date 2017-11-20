using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Movimiento_Jugador : MonoBehaviour {


    //Declaramos la variable de Rigidbody 
    private Rigidbody rig;

    [Header ("Movimiento")]
    //Declaramos la variable de velocidad con un valor de 10f
    public float speed = 10f;

    //Declaramos la variable de rotacion de la nave al moverse de los lados
    public float tilt = 4f;

    //Declaramos variables para definir los limites del moviento del jugador
    public float xMin, xMax, zMin, zMax;

    [Header("Objeto Disparo")]
    //Declaramos el GameObject para la bala
    public GameObject shot;

    //Declaramos el Transform para que la bala aparesca en el juego
    public Transform ShotSpawn;

    public float fireRate;
    public float nextFire;

	void Awake () {
        //Hacemos referencia Rigidbody para controlar el objeto 
        rig = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        //Definimos las variables de movimientos
        //Horizontal se mueve a los lados y Vetical se mueve hacia adelante y hacia atras
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Definimos movimientos de los vectores(x,y,z) en este caso y no se utiliza;
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); 

        //Multiplicamos la velocidad para que el objeto se mueva mas rapido dependiendo del valor asignado en el speed
        rig.velocity = movement * speed;

        //Limite de movimiento
        rig.position = new Vector3(Mathf.Clamp(rig.position.x,xMin,xMax),0f, Mathf.Clamp(rig.position.z, zMin, zMax));

        //Rota al moverse a los lados
        rig.rotation = Quaternion.Euler(0f,0f,rig.velocity.x*-tilt);
    }

    float vibrationAmount = 0.0f;

    private void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetAxis("FireB")<0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot,ShotSpawn.position, Quaternion.identity);
        }

        // Get the current gamepad state.
        GamePadState currentState = GamePad.GetState(PlayerIndex.One);

        // Process input only if connected and button A is pressed.
        if (currentState.Buttons.A == ButtonState.Pressed || Input.GetAxis("FireB") < 0)
        {
            // Button A is currently being pressed; add vibration.
            vibrationAmount = Mathf.Clamp(vibrationAmount + 0.3f, 0f, 0.3f);
            GamePad.SetVibration(PlayerIndex.One, vibrationAmount, vibrationAmount);
        }
        else
        {
            // Button A is not being pressed; subtract some vibration.
            vibrationAmount = Mathf.Clamp(vibrationAmount - 0.05f, 0.0f, 1.0f);
            GamePad.SetVibration(PlayerIndex.One, vibrationAmount, vibrationAmount);
        }

    }

}
