using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MSyun.Game.Input;
using MSyun.Common.Permanentry;
using MSyun.Common.Scene;

public class hogeSceneChange : MonoBehaviour
{
	private SystemInputModule input;
	private PermanentryManager permanent;

    // Start is called before the first frame update
    void Start()
    {
		permanent = PermanentryManager.Instance;
		input = permanent.GameController.CreateModuleSystem();
    }

    // Update is called once per frame
    void Update()
    {
		if (input.A()) {
			permanent.SceneManager.LoadScene(SceneName.Scene.GAME, true);
			permanent.SceneManager.UnloadSceneAsync(SceneName.Scene.TITLE, null);
		}
    }
}
