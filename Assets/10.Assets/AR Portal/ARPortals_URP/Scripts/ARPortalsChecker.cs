#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Lyceum.AR.Portal {
    [ExecuteInEditMode]
    public class ARPortalsChecker : MonoBehaviour {

        [SerializeField] private PortalController portal;
        [SerializeField] private List<GameObject> insidePortalObjects;
        [SerializeField] private UniversalRendererData forwardRendererData;
        [SerializeField] private UniversalRenderPipelineAsset universalRenderPipelineAsset;
        [SerializeField] private GameObject root;
        [SerializeField] private GameObject portalPrefab;
        private void Awake() {
            CheckLayers();
            CheckForwardRenderer();
            SetLayers();
            CheckQuality();
            CheckGraphics();
            AutoDeactivate();
        }

        private void CheckLayers() {
            TagsAndLayers.RemoveLayer("InsidePortal");
            TagsAndLayers.RemoveLayer("Mask");
            TagsAndLayers.RemoveLayer("Overrides");
            TagsAndLayers.CreateLayer("InsidePortal", 29);
            TagsAndLayers.CreateLayer("Mask", 30);
            TagsAndLayers.CreateLayer("Overrides", 31);
        }

        private void SetLayers() {
            portal.gameObject.layer = LayerMask.NameToLayer("Mask");
            insidePortalObjects = portal.insidePortalObjects;
            insidePortalObjects.ForEach(insidePortalObject => insidePortalObject.layer = LayerMask.NameToLayer("InsidePortal"));
            portal.layerWhenInside = LayerMask.GetMask("OutsidePortal");
            portal.layerWhenOutside = LayerMask.GetMask("InsidePortal");
            EditorUtility.SetDirty(portal);
            forwardRendererData.opaqueLayerMask &=  ~(1 << LayerMask.NameToLayer("OutsidePortal"));
            forwardRendererData.opaqueLayerMask &=  ~(1 << LayerMask.NameToLayer("InsidePortal"));
            forwardRendererData.opaqueLayerMask &=  ~(1 << LayerMask.NameToLayer("Mask"));
            forwardRendererData.transparentLayerMask &=  ~(1 << LayerMask.NameToLayer("OutsidePortal"));
            forwardRendererData.transparentLayerMask &=  ~(1 << LayerMask.NameToLayer("InsidePortal"));
            forwardRendererData.transparentLayerMask &=  ~(1 << LayerMask.NameToLayer("Mask"));
            MethodInfo dynMethod = forwardRendererData.GetType().GetMethod("OnValidate", BindingFlags.NonPublic | BindingFlags.Instance);
            dynMethod.Invoke(forwardRendererData, new object[]{});
        }

        private void CheckForwardRenderer() {
            forwardRendererData.rendererFeatures.OfType<RenderObjects>( ).ToList().ForEach(rendererFeature => {
                if (rendererFeature.name == "Mask") {
                    RenderObjects feature = (RenderObjects)rendererFeature;
                    feature.settings.filterSettings.LayerMask = (1 << LayerMask.NameToLayer("Mask"));
                }
                if (rendererFeature.name == "InsidePortal") {
                    RenderObjects feature = (RenderObjects)rendererFeature;
                    feature.settings.filterSettings.LayerMask = (1 << LayerMask.NameToLayer("InsidePortal"));
                }
                if (rendererFeature.name == "OutsidePortal") {
                    RenderObjects feature = (RenderObjects)rendererFeature;
                    feature.settings.filterSettings.LayerMask = (1 << LayerMask.NameToLayer("OutsidePortal"));
                }
            });
        }

        private void CheckQuality() {
            if (PlayerPrefs.HasKey("Lyceum.QualityAsked") && PlayerPrefs.GetInt("Lyceum.QualityAsked") == 1) {
                return;
            }
            if (QualitySettings.renderPipeline != universalRenderPipelineAsset) {
                int option = EditorUtility.DisplayDialogComplex("Quality settings maybe not correct",
                    "Do you want to changed to the ARPortals recommended Quality Settings? (If not see documentation to change manually)",
                    "Yes",
                    "No",
                    "Don't ask again");

                switch (option)
                {
                    // Save.
                    case 0:
                        QualitySettings.renderPipeline = universalRenderPipelineAsset;
                        break;

                    // Cancel.
                    case 1:
                        break;

                    // Don't Save.
                    case 2:
                        PlayerPrefs.SetInt("Lyceum.QualityAsked" , 1);
                        break;

                    default:
                        
                        break;
                }
            }
        }
        
        private void CheckGraphics() {
            if (PlayerPrefs.HasKey("Lyceum.GraphicsAsked") && PlayerPrefs.GetInt("Lyceum.GraphicsAsked") == 1) {
                return;
            }
            if (GraphicsSettings.renderPipelineAsset != universalRenderPipelineAsset) {
                int option = EditorUtility.DisplayDialogComplex("Graphics settings maybe not correct",
                    "Do you want to changed to the ARPortals recommended Graphics Settings? (If not see documentation to change manually)",
                    "Yes",
                    "No",
                    "Don't ask again");

                switch (option)
                {
                    // Save.
                    case 0:
                        GraphicsSettings.renderPipelineAsset = universalRenderPipelineAsset;
                        break;

                    // Cancel.
                    case 1:
                        break;

                    // Don't Save.
                    case 2:
                        PlayerPrefs.SetInt("Lyceum.GraphicsAsked" , 1);
                        break;

                    default:
                        
                        break;
                }
            }
        }

        private void AutoDeactivate() {
            this.gameObject.SetActive(false);
            try {
                PrefabUtility.ApplyPrefabInstance(portalPrefab, InteractionMode.UserAction);
            } catch {
                Debug.Log("Prefab already saved");
            }
        }
    }
}
#endif
