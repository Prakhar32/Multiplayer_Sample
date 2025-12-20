using NUnit.Framework;
using System;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BootstapSceneTests
{
    [UnityTest]
    [Timeout(7000)]
    public IEnumerator LoadGameplayLevel_whenAssetBundleandAddressablesareLoaded()
    {
        GameObject g = new GameObject();
        g.AddComponent<DependencyLoader>();
        bool gameplaySceneLoaded = false;
        SceneManager.activeSceneChanged += (scene1, scene2) => { 
            if(scene2.name.Equals(CommonConstants.GameplayScene))
                gameplaySceneLoaded = true;
        };

        yield return new WaitUntil(()  => gameplaySceneLoaded);
        Assert.Pass();
    }
}
