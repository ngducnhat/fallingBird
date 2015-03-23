using UnityEngine;
using System.Collections;

public class MainMenuScreen : BaseScreen {

	public UIPanel panel;

	public override void Init(params object[] inputs) {
		base.Init(inputs);
		panel = (Instantiate(Resources.Load(prefabPath + "MainMenuUI")) as GameObject).GetComponent<UIPanel>();
		panel.transform.parent = thisTransform;
	}
}
