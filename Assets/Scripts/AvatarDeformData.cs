using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AvatarDeformData", menuName = "Avatar/AvatarDeformData")]
public class AvatarDeformData : ScriptableObject {
    public Dictionary<string, Vector3[]> allFieldsValue;
    public string dataName;
    public int dataID;

    public AvatarDeformData() {
        this.allFieldsValue = GetAllFieldsValue();
    }

    private Vector3[] this[string name] {
        get {
            switch(name) {
                case "Head":
                    return this.head;
                case "Neck":
                    return this.neck;
                case "Spine":
                    return this.spine;
                case "Spine1":
                    return this.spine1;
                case "Spine2":
                    return this.spine2;
                case "Pelvis":
                    return this.pelvis;
                case "Thigh":
                    return this.thigh;
                case "Calf":
                    return this.calf;
                case "Clavicle":
                    return this.clavicle;
                case "UpperArm":
                    return this.upperArm;
                case "Forearm":
                    return this.foreArm;
                case "Hand":
                    return this.hand;
                case "Finger":
                    return this.finger;
                case "Foot":
                    return this.foot;
                case "Toe0":
                    return this.toe0;
                default:
                    return null;
            }
        }
    }

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

    /*
    public Vector3[] GetValueByFieldName1(string fieldName) {
        return this.allFieldsValue[fieldName];
    }
    */


    private Dictionary<string, Vector3[]> GetAllFieldsValue() {
        Dictionary<string, Vector3[]> AllFieldsValue = new Dictionary<string, Vector3[]>();
        AllFieldsValue["Head"] = this.head;
        AllFieldsValue["Neck"] = this.neck;
        AllFieldsValue["Spine2"] = this.spine2;
        AllFieldsValue["Spine1"] = this.spine1;
        AllFieldsValue["Spine"] = this.spine;
        AllFieldsValue["Pelvis"] = this.pelvis;
        AllFieldsValue["Thigh"] = this.thigh;
        AllFieldsValue["Calf"] = this.calf;
        AllFieldsValue["Clavicle"] = this.clavicle;
        AllFieldsValue["UpperArm"] = this.upperArm;
        AllFieldsValue["Forearm"] = this.foreArm;
        AllFieldsValue["Hand"] = this.hand;
        AllFieldsValue["Finger"] = this.finger;
        AllFieldsValue["Foot"] = this.foot;
        AllFieldsValue["Toe0"] = this.toe0;
        return AllFieldsValue;
    }


    public void CopyValuesFromAnotherData(AvatarDeformData avatarDeformData_Source) {
        // for every field
        foreach(string key in avatarDeformData_Source.allFieldsValue.Keys) {
            // for every Vector3 in field
            foreach(Vector3 values in this[key]) {
                this[key][0] = avatarDeformData_Source[key][0];
                this[key][1] = avatarDeformData_Source[key][1];
                this[key][2] = avatarDeformData_Source[key][2];
            }
        }

    }

}
