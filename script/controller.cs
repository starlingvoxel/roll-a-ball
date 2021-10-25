using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class controller : MonoBehaviour {
//Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro Jugador
private Rigidbody rb;
//Declaro la variable pública velocidad para poder modificarla desde la Inspector window
public float velocidad;
//Inicializo variables para los textos
public Text textoContador, textoGanar;

public int contador;
// Use this for initialization
void Start () {
//Capturo esa variable al iniciar el juego
rb = GetComponent<Rigidbody>();
//Inicio el contador a 0
contador = 0;

//Actualizo el texto del contador por pimera vez
setTextoContador();
//Inicio el texto de ganar a vacío
textoGanar.text = "";

}
// Para que se sincronice con los frames de física del motor
void FixedUpdate () {
//Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
float movimientoH = Input.GetAxis("Horizontal");
float movimientoV = Input.GetAxis("Vertical");
//Un vector 3 es un trío de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento

Vector3 movimiento = new Vector3(movimientoH, 0.0f,movimientoV);

//Asigno ese movimiento o desplazamiento a mi RigidBody,multiplicado por la velocidad que quiera darle
rb.AddForce(movimiento * velocidad);

}
//Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
void OnTriggerEnter(Collider other)
 {
 if (other.gameObject.CompareTag ("coleccionable"))
 {
     other.gameObject.SetActive (false);
     contador = contador + 1;
     //Actualizo elt exto del contador
     setTextoContador();

 
 }


 }
            //Actualizo el texto del contador (O muestro el de ganar si las ha cogido todas)
            void setTextoContador(){
            textoContador.text = "Contador: " + contador.ToString();
            if (contador >= 12){
            textoGanar.text = "¡Ganaste!";
            }
            }
}



