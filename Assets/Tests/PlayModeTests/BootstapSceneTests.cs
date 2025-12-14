using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class BootstapSceneTests
{
    [UnityTest]
    public IEnumerator CanLoadAssetBundle()
    {
        //Given
        AssetBundleLoader loader = new AssetBundleLoader();
        yield return loader.LoadBundle();
        yield return null;

        Assert.IsTrue(loader.GetLoadedBundle() != null);
    }
}
