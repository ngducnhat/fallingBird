using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

	public enum ScreenType {
		SPLASH = 0,
		MAIN_MENU,
		GAME
	}

	public ScreenType startScreen;

	// [HideInInspector]
	public BaseScreen currentScreen;
	// [HideInInspector]

	private Transform thisTransform;
	private Transform container;
	public ScreenType currentScreenId = 0;
	private ScreenType previousId = 0;

	public static Director Instance { get; private set; }


	public void Awake() {
		Instance = this;
		thisTransform = transform;
		container = new GameObject("Container").transform;
		container.position = Vector3.zero;
		container.parent = thisTransform;
		container.transform.localScale += new Vector3(0.0f, 0.0f, 0.001f);
		SetScreen(startScreen);

	}

	public void SetScreen(ScreenType screenId, params object[] inputs) {
		previousId = currentScreenId;
		currentScreenId = screenId;
		Reset();

		switch (currentScreenId) {
			case ScreenType.SPLASH:
				currentScreen = new GameObject("SplashScreen", typeof(SplashScreen)).GetComponent<SplashScreen>();				
			break;

			case ScreenType.MAIN_MENU:
				currentScreen = new GameObject("MainMenuScreen", typeof(MainMenuScreen)).GetComponent<MainMenuScreen>();				
			break;
		}

		currentScreen.name = currentScreen.GetType().ToString();
		currentScreen.Init(inputs);
		currentScreen.transform.parent = container;

	}

	public void Reset() {
		if (container != null) {
			Destroy(container.gameObject);
		}

		container = new GameObject("Container").transform;
		container.position = Vector3.zero;
		container.parent = thisTransform;
		container.transform.localScale += new Vector3(0.0f, 0.0f, 0.001f);
	}

}
