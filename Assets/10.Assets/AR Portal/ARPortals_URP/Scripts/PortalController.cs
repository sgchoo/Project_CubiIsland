// (c) 2020 Tongzhou Yu

using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Lyceum.AR.Portal {

    public class PortalController : MonoBehaviour {

        public float cameraForwardActivationPointOffset = 0.01f;

        [Tooltip("Seconds to reactive portal when enter it")]
        [SerializeField] private float secondsToReactivePortal = 0.1f;
        [Tooltip("Find inside portal object to inside portal objects list")]
        [SerializeField] private bool getInsidePortalObjectsChilds;
        [Tooltip("Objects that are inside portal")]
            public List<GameObject> insidePortalObjects = new List<GameObject>();
        private List<GameObject> insidePortalObjectsChilds = new List<GameObject>();
        [Tooltip("Layer of objects when user is inside portal")]
        public LayerMask layerWhenInside;
        [Tooltip("Layer of objects when user is outside portal")]
        public LayerMask layerWhenOutside;
        [SerializeField] private Transform insidePortalParent;
        private MeshRenderer meshRenderer;

        private Vector3 camPostionInPortalSpace;

        private bool wasInFront;
        private bool inOtherWorld;

        private bool hasCollided;
        private bool frontTraspassed;
        private bool cameraBacking;

        private bool isInFront;


        void Start() {
            if (getInsidePortalObjectsChilds) {
                GetInsidePortalObjectsChilds();
            }
            ChangeInsidePortalObjectsLayer(false);
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void GetInsidePortalObjectsChilds() {
            insidePortalObjects.ForEach(insidePortalObject => {
                foreach (Transform child in insidePortalObject.transform) {
                    insidePortalObjectsChilds.Add(child.gameObject);
                }
            });
            insidePortalObjects.AddRange(insidePortalObjectsChilds);
        }

        void ChangeInsidePortalObjectsLayer(bool fullRender) {
            insidePortalObjects.ForEach(insidePortalObject => {
                insidePortalObject.layer = LayermaskToLayer(fullRender ? layerWhenInside : layerWhenOutside);
            });
        }

        public static int LayermaskToLayer(LayerMask layerMask) {
            return (int)Mathf.Log(layerMask.value, 2);
        }

        //Get if camera is in front of portal
        private bool GetIsInFront() {
            Vector3 worldPos = Camera.main.transform.position + Camera.main.transform.forward * (Camera.main.nearClipPlane + cameraForwardActivationPointOffset);
            camPostionInPortalSpace = transform.InverseTransformPoint(worldPos);
            return camPostionInPortalSpace.y >= 0 ? true : false;
        }

        private void OnTriggerEnter(Collider collider) {
            if (collider.transform != Camera.main.transform)
                return;
            wasInFront = GetIsInFront();
            hasCollided = true;
        }

        private void OnTriggerExit(Collider collider) {            
            if (collider.transform != Camera.main.transform)
                return;
            hasCollided = false;
        }

        private void RunPortal() {
            if (!hasCollided) {
                return;
            }
            isInFront = GetIsInFront();
            if ((isInFront && !wasInFront) || (wasInFront && !isInFront)) {
                inOtherWorld = !inOtherWorld;
                ChangeInsidePortalObjectsLayer(inOtherWorld);
                StartCoroutine(PortalCoroutine());
                frontTraspassed = true;
            }
            CheckTraspassed();
            wasInFront = isInFront;
        }

        private void OnDestroy() {
            ChangeInsidePortalObjectsLayer(true);
        }

        private void Update() {
            RunPortal();
        }

        private bool IsCameraInMid() {
            bool cameraCenterIsInFront = transform.InverseTransformPoint(Camera.main.transform.position).y >= 0 ? true : false;
            return isInFront != cameraCenterIsInFront;
        }

        private void CheckTraspassed() {
            if (!IsCameraInMid()) {
                frontTraspassed = false;
            }
            if(!frontTraspassed && IsCameraInMid()) {
                cameraBacking = true;
                meshRenderer.enabled = false;
            }
        }

        private IEnumerator PortalCoroutine() {
            if (cameraBacking) {
                cameraBacking = false;
                meshRenderer.enabled = true;
                yield return null;
            } else {
                meshRenderer.enabled = false;
                yield return new WaitForSeconds(secondsToReactivePortal);
                meshRenderer.enabled = true;
            }
        }

#if UNITY_EDITOR
        public void AddInsidePortalObject(GameObject gameObject) {
            GameObject insideObject = Instantiate(gameObject, insidePortalParent);
            SetLayerRecursively(insideObject,"InsidePortal");
            insideObject.transform.position = gameObject.transform.position;
            AddObjectsRecursivelyToList(insidePortalObjects, insideObject);
            PrefabUtility.UnpackPrefabInstance(PrefabUtility.GetOutermostPrefabInstanceRoot(this.gameObject), PrefabUnpackMode.Completely, InteractionMode.UserAction);
        }

        private void AddObjectsRecursivelyToList(List<GameObject> list, GameObject obj) {
            if (null == obj) {
                return;
            }
            
            list.Add(obj);
       
            foreach (Transform child in obj.transform) {
                if (null == child)
                {
                    continue;
                }
                AddObjectsRecursivelyToList(list, child.gameObject);
            }
        }
#endif
        
        private void SetLayerRecursively(GameObject obj, string newLayer)
        {
            if (null == obj)
            {
                return;
            }
       
            obj.layer = LayerMask.NameToLayer(newLayer);
       
            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(PortalController))]
    [CanEditMultipleObjects]
    public class PortalControllerEditor : Editor {

        public string questionId;
        public GameObject objectToInside;
        void OnEnable() {
			
        }

        public override void OnInspectorGUI() {
            DrawDefaultInspector();
			
            PortalController myTarget = (PortalController)target;
            
            objectToInside = (GameObject) EditorGUILayout.ObjectField("Gameobject To Put Inside", objectToInside, typeof(GameObject), true);

            if (GUILayout.Button("Add Gameobject To Inside Portal Objects")) {
                myTarget.AddInsidePortalObject(objectToInside);
            }
        }
    }
#endif
}
