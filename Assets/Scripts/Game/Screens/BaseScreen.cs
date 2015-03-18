using UnityEngine;
using System.Collections;

public class BaseScreen : MonoBehaviour {

	protected Transform thisTransform;
	protected string prefabPath = "Prefabs/";	

	public virtual void Awake() {
		thisTransform = transform;

	}

	public virtual void Init(params object[] inputs) {
		prefabPath = "Prefabs/Screens/" + name + "/";		
		Time.timeScale = 1.0f;

	}

	// public virtual void Destroy(){}
	
}
