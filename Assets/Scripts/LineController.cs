using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {


	public Transform target;
	public float speed;
	private bool goToTarget;

	void Start(){
		StartCoroutine ("FindTarget");
	}

	void Update() {
		if (goToTarget) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}
		
	public IEnumerator FindTarget(){
		yield return new WaitForSeconds (3.0f);
		goToTarget = true;

		yield return 0;
	}

}
