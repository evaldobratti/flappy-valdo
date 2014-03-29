using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public TextMesh score;
	public TextMesh scoreShadow;
	private int _valor;

	public int Valor {
		get {
			return _valor;
		}
		set {
			_valor = value;
		}
	}

	// Use this for initialization
	void Start () {
		Valor = 0;
	}

	public void Scored() {
		Valor = Valor + 1;
	}
	// Update is called once per frame
	void Update () {
		score.text = Valor.ToString ();
		scoreShadow.text = Valor.ToString ();
	}

	public void Disable() {
		setRedenderEnabled (false);
	}

	public void Enable() {
		setRedenderEnabled (true);
	}

	private void setRedenderEnabled (bool enabled)
	{
		score.renderer.enabled = enabled;
		scoreShadow.renderer.enabled = enabled;
	}
}


