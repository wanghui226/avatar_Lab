using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BipedSizeData", menuName = "AvatarData/BipedSizeData")]
public class BipedSizeData_Thin : ScriptableObject {
    [Range(0, 1)]
    public float headSize = 0.5f;
    
}
