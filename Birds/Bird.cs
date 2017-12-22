﻿using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(Trail))]
public class Bird : MonoBehaviour {

    private Trail trail;

    [HideInInspector]
    public bool shot = false;

    [SerializeField]
    private ParticleSystem collisionPS;

    private void Awake() {
        trail = GetComponent<Trail>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (shot) {
            collisionPS.Emit(10);
            OnImpact();
        }
    }

    public virtual void OnImpact() {
        if (TrailManager.instance.trailList.Count > 1) {
            TrailManager.instance.trailList[TrailManager.instance.trailList.Count - 2].DisableTrail();
            TrailManager.instance.trailList.RemoveAt(TrailManager.instance.trailList.Count - 2);
        }

        trail.enabled = false;

        print("Bird: I hit something");
    }
}
