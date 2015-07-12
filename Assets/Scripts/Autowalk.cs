// Autowalk, permite controlar a traves de ligeros movimientos de la cardboard el avance del jugador
// Ultima edicion: 05/Julio/2015
// MCC Games - Gerick Toro

using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour 
{

	public Rigidbody shotPrefab;
	public float shotPower = 100f;
	public GameObject soldado;
	private const int RIGHT_ANGLE = 90; 
	private const int BACK_ANGLE = 360; 

	
	// Estas variables determinan si el jugador se mueve o no, (adelante y atras)
	private bool isWalking = false;
	private bool isWalkingBack = false;
	
	CardboardHead head = null;

	float timer = 0f;
	Transform currentTarget;
	AudioSource source;
	
	//Esta variable define la velocidad del personaje
	[Tooltip("Velocidad a la que el personaje se movera.")]
	public float speed;

	[Tooltip("Activar los chekboxs para que el personaje pueda moverse con la cabeza y el iman.")]
	public bool SpinWhenTriggered;
	public bool walkWhenLookDown;
	public bool walkWhenLookUp;
	
	[Tooltip("Angulo de movimiento sobre la base de 90°")]
	public double thresholdAngle;
	public double thresholdAngleBack;
	
	[Tooltip("Activate this Checkbox if you want to freeze the y-coordiante for the player. " +
	         "For example in the case of you have no collider attached to your CardboardMain-GameObject" +
	         "and you want to stay in a fixed level.")]
	public bool freezeYPosition; 
	
	[Tooltip("Correcion para el eje Y.")]
	public float yOffset;

	[Tooltip("Smooth para girar")]
	public float smooth = 1f;
	private Quaternion targetRotation;
	
	//para la animacion
	public Animator animator;

	void Start () 
	{
		head = Camera.main.GetComponent<StereoController>().Head;
	
	}
	
	void Update () 
	{

		//Debug.Log (head.transform.eulerAngles.x);
		//Spin
		if (SpinWhenTriggered && Cardboard.SDK.Triggered) 
		{

			//Girar la pantalla
			//transform.RotateAround (transform.position, transform.up, 180f);
			//disparo = GameObject.FindGameObjectWithTag("Shot");
			//shotPrefab = disparo.GetComponent<Rigidbody>();
			Debug.Log("Dispara");
			animator.SetBool("ClickOn", true);
			//shotPrefab = GameObject.FindGameObjectWithTag("Shot");
			Rigidbody shot = Instantiate(shotPrefab, transform.position, transform.rotation) as Rigidbody;
			soldado = GameObject.FindGameObjectWithTag("Soldado");
			shot.AddForce(soldado.transform.forward * shotPower, ForceMode.Impulse);
			timer = 0f;
			//source.Play();



		} 

		
		// Avanza el jugador, si mueve abajo el cardboard
		if (walkWhenLookDown && walkWhenLookUp && !isWalking && !isWalkingBack &&  
		    head.transform.eulerAngles.x >= thresholdAngle && 
		    head.transform.eulerAngles.x <= RIGHT_ANGLE) 
		{
			isWalking = true;
			animator.SetBool("Idle", true);
		} 
		else if (walkWhenLookDown && walkWhenLookUp && isWalking && !isWalkingBack && 
		         (head.transform.eulerAngles.x <= thresholdAngle ||
		 head.transform.eulerAngles.x >= RIGHT_ANGLE)) 
		{
			isWalking = false;
			animator.SetBool("Idle", true);
		}



		// Retrocede el jugador, si mueve arriba el cardboard
		if (walkWhenLookUp && walkWhenLookDown && !isWalkingBack && !isWalking &&  
		    head.transform.eulerAngles.x >= thresholdAngleBack && 
		    head.transform.eulerAngles.x <= BACK_ANGLE) 
		{
			isWalkingBack = true;
			animator.SetBool("Idle", true);

		} 
		else if (walkWhenLookUp && walkWhenLookDown && isWalkingBack && !isWalking && 
		         (head.transform.eulerAngles.x <= thresholdAngleBack ||
		 head.transform.eulerAngles.x >= BACK_ANGLE)) 
		{
			isWalkingBack = false;
			animator.SetBool("Idle", true);

		}



		// Accion de Avanzar		
		if (isWalking) 
		{
			Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate(rotation * direction);
		}

		//Accion de Retroceder
		if (isWalkingBack) 
		{
			Vector3 direction = new Vector3(-head.transform.forward.x, 0, -head.transform.forward.z).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate(rotation * direction);
		}
		
		if(freezeYPosition)
		{
			transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
		}
	}
}