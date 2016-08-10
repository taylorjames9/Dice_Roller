using UnityEngine;
using System.Collections;

public class numberFlicker : MonoBehaviour {



	public TextMesh textField;
	private int i =0; 
	private int pokeDice;
	public float al;

	public GameObject diceLine_1;
	public GameObject diceLine_2;



	void OnCollisionEnter(Collision collision) {
		Debug.Log ("I got hit " + pokeDice);

		if (collision.gameObject.tag.Equals ("line")) {
			pokeDice++;
			Debug.Log ("I got hit " + pokeDice);
			if (pokeDice > 0) {
				GetComponent<TextMesh> ().text = "";
			}

			if (pokeDice > 1) {
				StartCoroutine (NumberFlickering (0.01f));
				pokeDice = 0;
			}
		}
	}

	void Start(){
		//StartCoroutine (NumberFlickering (0.01f));
		GetComponent<TextMesh> ().text = "";
	}


	public IEnumerator NumberFlickering(float interval){
		if(interval >= 0.03f){
			interval = 0;
			diceLine_1.SetActive (false);
			diceLine_2.SetActive (false);
			yield return new WaitForSeconds (0.75f);
			yield return StartCoroutine (FadeOutNumber (1.0f));
		} else {
			Debug.Log ("start the flicker");
			interval*= 1.0001f;
			interval+= 0.001f;
			textField.text = Random.Range (2, 12).ToString ();
			yield return new WaitForSeconds (interval);
			yield return StartCoroutine(NumberFlickering(interval));
		}
	}


	public IEnumerator FadeOutNumber (float alpha){
		if (GetComponent<TextMesh> ().color.a <= 0.0f) {
			//GetComponent<TextMesh> ().gameObject.SetActive (false);
			Debug.Log ("We're faded out");
			yield return 0;
		} else {
			Debug.Log ("We're working on fading out");
			alpha -= 0.25f;
			al = alpha;
			GetComponent<TextMesh> ().color = new Color (255, 255, 255, al);
			yield return StartCoroutine (FadeOutNumber(alpha));
		}

	}

}
