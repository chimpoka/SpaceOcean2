using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader
{
    private int NextLevelBuildIndex;
    private GameObject LevelLoaderObject;
    private LevelLoaderAnimatorEvent AnimatorEvent;

    public void LoadLevel(int BuildIndex)
    {
        AnimatorEvent = CreateLoadLevelAnimatorEvent();
        AnimatorEvent.OnFadeOutCompleted += LoadNextScene;
        AnimatorEvent.FadeOut();

        NextLevelBuildIndex = BuildIndex;
    }



    private LevelLoaderAnimatorEvent CreateLoadLevelAnimatorEvent()
    {
        LevelLoaderObject = MonoBehaviour.Instantiate(Resources.Load("HUD/GameScene/LevelLoader/LevelLoader")) as GameObject;

        LevelLoaderAnimatorEvent[] LLAE = LevelLoaderObject.GetComponentsInChildren<LevelLoaderAnimatorEvent>(true);

        foreach (LevelLoaderAnimatorEvent animEvent in LLAE)
        {
            animEvent.gameObject.SetActive(false);
        }

        LLAE[0].gameObject.SetActive(true);
        return LLAE[0];

        return LevelLoaderObject.GetComponentInChildren<LevelLoaderAnimatorEvent>();
    }

    private void LoadNextScene()
    {
        SceneManager.sceneLoaded += OnNextSceneLoaded;
        SceneManager.LoadScene(NextLevelBuildIndex); 
    }

    private void OnNextSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AnimatorEvent = CreateLoadLevelAnimatorEvent();
        AnimatorEvent.OnFadeInCompleted += DestroyLevelLoaderObject;
        AnimatorEvent.FadeIn();
    }

    private void DestroyLevelLoaderObject()
    {
        if (LevelLoaderObject)
            MonoBehaviour.Destroy(LevelLoaderObject);
    }
}
