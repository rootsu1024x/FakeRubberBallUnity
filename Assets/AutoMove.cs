using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {

	void Start () {

	}

	IEnumerator Move(){
		yield return new WaitForSeconds (4.5f);
		while (true) {
			rigidbody.AddForce (new Vector3 (1, 2, 0),ForceMode.Force);
			yield return new WaitForSeconds (4.5f);
			rigidbody.AddForce (new Vector3 (-1, 2, 0),ForceMode.Force);
			yield return new WaitForSeconds (4.5f);
		}
	}

	void Update () {
		StartCoroutine (Move ());
	}
}
