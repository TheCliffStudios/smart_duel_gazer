using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToPlace;
    [SerializeField]
    private GameObject _placementIndicator;

    private GameObject _placedObject;
    public GameObject PlacedObject => _placedObject;

    private Pose _placementPose;
    private ARRaycastManager _arRaycastManager;
    private bool _placementPoseIsValid = false;
    private bool _objectIsPlaced = false;

    void Start()
    {
        _arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (_objectIsPlaced)
        {
            return;
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (_placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        _arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        _placementPoseIsValid = hits.Count > 0;
        if (_placementPoseIsValid)
        {
            _placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            _placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (_placementPoseIsValid)
        {
            _placementIndicator.SetActive(true);
            _placementIndicator.transform.SetPositionAndRotation(_placementPose.position, _placementPose.rotation);
        }
        else
        {
            _placementIndicator.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        _objectIsPlaced = true;
        _placementIndicator.SetActive(false);
        _placedObject = Instantiate(_objectToPlace, _placementPose.position, _placementPose.rotation);
    }
}