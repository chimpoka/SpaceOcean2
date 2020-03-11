using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObjects / LevelLoader")]
public class LevelLoader : ScriptableObject
{
    [SerializeField]
    private GameObject DefaultCanvas;
    [SerializeField]
    private LoadScreen[] LoadScreenObjects;

    private int NextLevelBuildIndex;
    private GameObject CanvasObject;

    public void LoadLevel(int BuildIndex)
    {
        LoadScreen LoadScreen = CreateLoadScreen();
        LoadScreen.OnFadeOutCompleted += LoadNextScene;
        LoadScreen.FadeOut();

        NextLevelBuildIndex = BuildIndex;
    }



    private LoadScreen CreateLoadScreen()
    {
        CanvasObject = Instantiate(DefaultCanvas);
        //int RandomIndex = Random.Range(0, LoadScreenObjects.Length);
        LoadScreen AnimatorEvent = Instantiate(LoadScreenObjects[0]);
        AnimatorEvent.gameObject.transform.SetParent(CanvasObject.transform, false);

        return AnimatorEvent;
    }

    private void LoadNextScene()
    {  
        SceneManager.sceneLoaded += OnNextSceneLoaded;
        SceneManager.LoadScene(NextLevelBuildIndex);
    }

    private void OnNextSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnNextSceneLoaded;
        LoadScreen LoadScreen = CreateLoadScreen();
        LoadScreen.OnFadeInCompleted += DestroyLoadScreen;
        LoadScreen.FadeIn();
    }

    private void DestroyLoadScreen()
    {
        if (CanvasObject)
            Destroy(CanvasObject);
    }
}
