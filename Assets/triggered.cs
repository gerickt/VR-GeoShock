using UnityEngine;
using System.Collections;

public class triggered : MonoBehaviour {
	private int cpCount;
	public GameObject dial;
	public GameObject dial2;
	public GameObject dial3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			dial.SetActive (true);
			dial2.SetActive (true);
			dial3.SetActive (true);
			Debug.Log("activate");
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			dial.SetActive (false);
			dial2.SetActive (false);
			dial3.SetActive (false);

			Debug.Log("deactive");
		}
	}
}
