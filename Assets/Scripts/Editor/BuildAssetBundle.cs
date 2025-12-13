using System.IO;
using UnityEngine;
using UnityEditor;

public class BuildAssetBundlesExample
{
    [MenuItem("Asset Bundles/Build AssetBundles")]
    static void BuildBundles()
    {
        string outputPath = Application.dataPath + "/../AssetBundles";
        if (!Directory.Exists(outputPath))
            Directory.CreateDirectory(outputPath);

        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, 
            BuildAssetBundleOptions.UseContentHash, EditorUserBuildSettings.activeBuildTarget);
    }
}