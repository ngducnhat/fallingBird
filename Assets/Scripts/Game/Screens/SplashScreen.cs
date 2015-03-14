using UnityEngine;
using System.Collections;

public class SplashScreen : BaseScreen {

	public UIPanel panel;

	protected bool isShowing = false;
	protected bool isTweening = false;
	protected float secondsToTween = 1.00f;

	public override void Init(params object[] inputs) {
		base.Init(inputs);
		Debug.Log(prefabPath);
		panel = (Instantiate(Resources.Load(prefabPath + "SplashUI")) as GameObject).GetComponent<UIPanel>();
		panel.transform.parent = thisTransform;
		panel.alpha = 0.0f;
		Show();
	}

	public virtual void Show() {
		if (!isShowing) {
			LeanTween.value(gameObject, ChangeAlpha, 0.0f, 1.0f, secondsToTween).setOnComplete(FinishShowTween);
			isTweening = true;
		}
	}

	public virtual void Hide() {
		if (isShowing) {
			LeanTween.value(gameObject, ChangeAlpha, 1.0f, 0.0f, secondsToTween).setOnComplete(FinishHideTween);
			isTweening = true;
		}
	}

	public void ChangeAlpha(float value) {
		panel.alpha = value;		
	}

	public void FinishShowTween() {
		isShowing = true;
		isTweening = false;		
		Invoke("Hide", 0.5f);
	}

	public void FinishHideTween() {
		isShowing = !isShowing;
		isTweening = false;
		// Director.Instance.SetScreen(Director.ScreenType.MAIN_MENU);
	}
	
}
