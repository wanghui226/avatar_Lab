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
                case "head":
                    return this.head;
                case "neck":
                    return this.neck;
                case "spine":
                    return this.spine;
                case "spine1":
                    return this.spine1;
                case "spine2":
                    return this.spine2;
                case "pelvis":
                    return this.pelvis;
                case "thigh":
                    return this.thigh;
                case "calf":
                    return this.calf;
                case "clavicle":
                    return this.clavicle;
                case "upperArm":
                    return this.upperArm;
                case "foreArm":
                    return this.foreArm;
                case "hand":
                    return this.hand;
                case "finger":
                    return this.finger;
                case "foot":
                    return this.foot;
                case "toe0":
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
        AllFieldsValue["head"] = this.head;
        AllFieldsValue["neck"] = this.neck;
        AllFieldsValue["spine2"] = this.spine2;
        AllFieldsValue["spine1"] = this.spine1;
        AllFieldsValue["spine"] = this.spine;
        AllFieldsValue["pelvis"] = this.pelvis;
        AllFieldsValue["thigh"] = this.thigh;
        AllFieldsValue["calf"] = this.calf;
        AllFieldsValue["clavicle"] = this.clavicle;
        AllFieldsValue["upperArm"] = this.upperArm;
        AllFieldsValue["foreArm"] = this.foreArm;
        AllFieldsValue["hand"] = this.hand;
        AllFieldsValue["finger"] = this.finger;
        AllFieldsValue["foot"] = this.foot;
        AllFieldsValue["toe0"] = this.toe0;
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
