using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImage : MonoBehaviour {
    // Start is called before the first frame update
    ARTrackedImageManager aim;

    public GameObject prefabSakeCup;
    GameObject createdSakeCup;

    public GameObject prefabCurtain;
    GameObject createdCurtain;

    public GameObject prefabMoon;
    GameObject createdMoon;

    public GameObject prefabCrane;
    GameObject createdCrane;

    public GameObject prefabPhoenix;
    GameObject createdPhoenix;

    public GameObject prefabRain;
    GameObject createdRain;

    void Awake(){
        aim = GetComponent<ARTrackedImageManager>();   
    }

    void OnEnable(){

        aim.trackedImagesChanged += OnTrackedImagesChanged;
        
    }

    void OnDisable(){

        aim.trackedImagesChanged -= OnTrackedImagesChanged;

    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) {

        foreach (ARTrackedImage tracked in eventArgs.added) {

            string name = tracked.referenceImage.name;
            if (name == "SakeCup")
            {
                createdSakeCup = Instantiate(prefabSakeCup, tracked.transform);
            }
            if (name == "Curtain") {

                createdCurtain = Instantiate(prefabCurtain, tracked.transform);
            }
            if (name == "Moon")
            {
                createdMoon = Instantiate(prefabMoon, tracked.transform);

            }
            if (name == "Crane")
            {
                createdCrane = Instantiate(prefabCrane, tracked.transform);

            }
            if (name == "Phoenix")
            {
                createdPhoenix = Instantiate(prefabPhoenix, tracked.transform);

            }
            if (name == "Rain")
            {
                createdRain = Instantiate(prefabRain, tracked.transform);

            }
        }

        foreach (ARTrackedImage tracked in eventArgs.removed) {
            string name = tracked.referenceImage.name;
            if (name == "SakeCup")
            {
                Destroy(createdSakeCup);
                createdSakeCup = null;
            }
            if (name == "Curtain")
            {
                Destroy(createdCurtain);
                createdCurtain = null;
            }
            if (name == "Moon")
            {
                Destroy(createdMoon);
                createdMoon = null;

            }
            if (name == "Crane")
            {
                Destroy(createdCrane);
                createdCrane = null;

            }
            if (name == "Phoenix")
            {
                Destroy(createdPhoenix);
                createdPhoenix = null;

            }
            if (name == "Rain")
            {
                Destroy(createdRain);
                createdRain = null;

            }
        }

        foreach (ARTrackedImage tracked in eventArgs.updated) {
            string name = tracked.referenceImage.name;
            if (name == "SakeCup")
            {
                createdSakeCup.SetActive(tracked.trackingState != TrackingState.None);
            }
            if (name == "Curtain")
            {
                createdCurtain.SetActive(tracked.trackingState != TrackingState.None);
            }
            if (name == "Moon")
            {
                createdMoon.SetActive(tracked.trackingState != TrackingState.None);

            }
            if (name == "Crane")
            {
                createdCrane.SetActive(tracked.trackingState != TrackingState.None);

            }
            if (name == "Phoenix")
            {
                createdPhoenix.SetActive(tracked.trackingState != TrackingState.None);

            }
            if (name == "Rain")
            {
                createdRain.SetActive(tracked.trackingState != TrackingState.None);

            }
        }


    }

}
