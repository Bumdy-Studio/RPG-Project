using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {

    [SerializeField] private Vector3 movement;
    [SerializeField] private float movementSpeed = 1;
    
    private bool goingTowards = false;
    private Vector3 localStartingPosition;

    void Start() {
        localStartingPosition = transform.localPosition;
    }
    
    void Update() {
        Vector3 goToPosition = goingTowards ? localStartingPosition : localStartingPosition + movement;

        transform.localPosition = Vector3.Slerp(transform.localPosition, goToPosition, movementSpeed);

        if (Vector3.Distance(goToPosition, transform.localPosition) < 0.1) {
            goingTowards = !goingTowards;
        }
    }
}
