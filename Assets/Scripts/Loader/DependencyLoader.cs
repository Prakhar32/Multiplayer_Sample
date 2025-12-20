using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class DependencyLoader : MonoBehaviour
{
    AssetBundle _bundle;

    void Start()
    {
        StartCoroutine(loadDependencies());
    }

    private IEnumerator loadDependencies()
    {
        AssetBundleLoader loader = new AssetBundleLoader(this);
        yield return StartCoroutine(loadBundle(loader));
        yield return StartCoroutine(loadAddressable());
        loadScene();
    }

    private IEnumerator loadBundle(AssetBundleLoader loader)
    {
        yield return loader.LoadBundle();
        _bundle = loader.GetLoadedBundle();
    }

    private IEnumerator loadAddressable()
    {
        yield return Addressables.InitializeAsync();
    }

    private void loadScene()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadSceneAsync(CommonConstants.GameplayScene, LoadSceneMode.Additive);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.SetActiveScene(arg0);
    }
}
