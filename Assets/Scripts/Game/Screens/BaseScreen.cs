using UnityEngine;
using System.Collections;

public class BaseScreen : MonoBehaviour {

	protected Transform thisTransform;

	public virtual void Awake() {
		thisTransform = transform;

	}

	public virtual void Init(params object[] inputs) {
		Time.timeScale = 1.0f;
	}

	public virtual void Destroy(){}
	
}
