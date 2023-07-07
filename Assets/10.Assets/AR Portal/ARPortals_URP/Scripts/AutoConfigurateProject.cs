using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
#if UNITY_EDITOR
using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
#endif
using UnityEngine;
using Object = UnityEngine.Object;

public class AutoConfigurateProject : MonoBehaviour {
#if UNITY_EDITOR
    public UniversalRenderPipelineAsset renderPipelineAsset;
    public List<TextAsset> toActiveScripts = new List<TextAsset>();
    public GameObject ARPortalsPrefab;
    public void AutoConfigure() {
        TagsAndLayers.RemoveLayer("OutsidePortal");
        TagsAndLayers.RemoveLayer("InsidePortal");
        TagsAndLayers.RemoveLayer("Mask");
        TagsAndLayers.RemoveLayer("Overrides");
        TagsAndLayers.CreateLayer("OutsidePortal", 28);
        TagsAndLayers.CreateLayer("InsidePortal", 29);
        TagsAndLayers.CreateLayer("Mask", 30);
        TagsAndLayers.CreateLayer("Overrides", 31);
        ListRequest listRequest = Client.List();
        UnityEditor.PackageManager.Client.Add("com.unity.xr.arfoundation@4.1.7");
        RemoveCommentsFromScripts();
        //PrefabUtility.LoadPrefabContentsIntoPreviewScene(AssetDatabase.GetAssetPath(ARPortalsPrefab), SceneManager.GetActiveScene());
        Type t = typeof(UnityEditor.SceneManagement.PrefabStageUtility);
        MethodInfo mi = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public |BindingFlags.Static).Single(m => m.Name == "OpenPrefab" && m.GetParameters().Length == 1
            && m.GetParameters()[0].ParameterType == typeof(string) ); 
        mi.Invoke(null, new object[] {AssetDatabase.GetAssetPath(ARPortalsPrefab)}); 
    }
    
    private void RemoveCommentsFromScripts() {
        toActiveScripts.ForEach(script => {
            string path = AssetDatabase.GetAssetPath((Object)script);
            string noCommentsScript = script.text.Replace("#if false", "");
            noCommentsScript = noCommentsScript.Replace("#endif", "");
            File.WriteAllText(path, noCommentsScript);
            AssetDatabase.ImportAsset(path);
        });
    }

    public void InstallARCore() {
        UnityEditor.PackageManager.Client.Add("com.unity.xr.arcore@4.1.7");
    }
    
    public void InstallARKit() {
        UnityEditor.PackageManager.Client.Add("com.unity.xr.arkit@4.1.7");
    }
#endif
}

#if UNITY_EDITOR
    [CustomEditor(typeof(AutoConfigurateProject))]
    [CanEditMultipleObjects]
    public class AutoConfigurateProjectEditor : Editor {

        void OnEnable() {

        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            //DrawDefaultInspector();

            AutoConfigurateProject myTarget = (AutoConfigurateProject)target;

            if (GUILayout.Button("AutoConfigure")) {
                myTarget.AutoConfigure();
            }
            
            if (GUILayout.Button("InstallARCore")) {
                myTarget.InstallARCore();
            }
            
            if (GUILayout.Button("InstallARKit")) {
                myTarget.InstallARKit();
            }
        }
    }
#endif