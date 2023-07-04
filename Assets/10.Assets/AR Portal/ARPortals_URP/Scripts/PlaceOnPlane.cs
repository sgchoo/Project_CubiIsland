 using System.Collections.Generic;
 using UnityEngine;
 #if false
 using UnityEngine.XR.ARFoundation;
 using UnityEngine.XR.ARSubsystems;
#endif

 /// <summary>
 /// Listens for touch events and performs an AR raycast from the screen touch point.
 /// AR raycasts will only hit detected trackables like feature points and planes.
 ///
 /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
 /// and moved to the hit position.
 /// </summary>

#if false
 [RequireComponent(typeof(ARRaycastManager))]

#endif
 public class PlaceOnPlane : MonoBehaviour
 {
     [SerializeField]
     [Tooltip("Instantiates this prefab on a plane at the touch location.")]
     GameObject m_PlacedPrefab;



     /// <summary>
     /// The prefab to instantiate on touch.
     /// </summary>
     public GameObject placedPrefab
     {
         get { return m_PlacedPrefab; }
         set { m_PlacedPrefab = value; }
     }

     /// <summary>
     /// The object instantiated as a result of a successful raycast intersection with a plane.
     /// </summary>
     public GameObject spawnedObject { get; private set; }

     
#if false

     void Awake()
     {
         m_RaycastManager = GetComponent<ARRaycastManager>();
     }

     bool TryGetTouchPosition(out Vector2 touchPosition)
     {
         if (Input.touchCount > 0)
         {
             touchPosition = Input.GetTouch(0).position;
             return true;
         }

         touchPosition = default;
         return false;
     }

     void Update()
     {
         if (!TryGetTouchPosition(out Vector2 touchPosition))
             return;

         if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
         {
             Debug.Log("Touch screen");
             var hitPose = s_Hits[0].pose;

             if ((spawnedObject == null))
             {
                 spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                 Debug.Log("spawnedObject:" );
             }
             else
             {
                 Debug.Log("spawnedObject != null " + spawnedObject.transform.position);
                 spawnedObject.transform.position = hitPose.position;
             }
         }
     }

     static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

     ARRaycastManager m_RaycastManager;

#endif
 }
