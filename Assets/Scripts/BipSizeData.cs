using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BipSizeData", menuName = "MyAsset/BipSizeData")]
public class BipSizeData : ScriptableObject {
    public List<float> bipThinY = new List<float>();
    public List<float> bipThinZ = new List<float>();
    public List<Vector3> bipThinPos = new List<Vector3>();
    public List<float> bipFatY = new List<float>();
    public List<float> bipFatZ = new List<float>();
    public List<Vector3> bipFatPos = new List<Vector3>();
    public List<float> bipStrongY = new List<float>();
    public List<float> bipStrongZ = new List<float>();
    public List<Vector3> bipStrongPos = new List<Vector3>();
}
