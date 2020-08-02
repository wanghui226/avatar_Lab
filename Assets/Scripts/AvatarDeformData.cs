using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AvatarDeformData", menuName = "Avatar/AvatarDeformData")]
public class AvatarDeformData : ScriptableObject {
    public string dataName;
    public uint dataID;
    public Vector3[] head = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] neck = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] spine2 = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] spine1 = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] spine = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };

    public Vector3[] pelvis = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] thigh = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] calf = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] clavicle = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] upperArm = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] foreArm = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] hand = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] finger = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] foot = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };
    public Vector3[] toe0 = new Vector3[] {
        Vector3.zero,
        Vector3.zero,
        Vector3.one
    };





}
