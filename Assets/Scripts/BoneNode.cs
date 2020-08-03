using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneNode : MonoBehaviour {
    private string[] allBoneType = { "Pelvis", "Spine", "Spine1", "Spine2", "Thigh", "Calf", "Neck", "Head", "Clavicle", "UpperArm", "Forearm", "Hand", "Finger", "Foot", "Toe0" };
    private SkinnedMeshRenderer playerSkin;
    private Transform[] allbones;
    public List<Transform> BoneChlidrenNode;
    public BipSizeData BoneValue;
    private List<List<Transform>> boneType = new List<List<Transform>>();
    void Awake() {
        Vector3 PlayeLocalScale = this.transform.localScale;
        playerSkin = this.GetComponentInChildren<SkinnedMeshRenderer>();
        allbones = playerSkin.bones;
        if(allbones == null || PlayeLocalScale == null || BoneChlidrenNode == null || allBoneType == null || playerSkin == null || BoneValue == null) {
            return;
        } else {
            BoneScale.CreatBipChildrenNode(allbones, PlayeLocalScale, BoneChlidrenNode);
            playerSkin.bones = BoneChlidrenNode.ToArray();
            for(int i = 0; i < allBoneType.Length; i++) {
                boneType.Add(BoneScale.BoneGroupFind(playerSkin.bones, allBoneType[i], playerSkin));
            }
            BoneScale.SetBipValue(BoneValue);
            BoneScale.SetBoneType(boneType);
        }
    }

}

