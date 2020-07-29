using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneScale{
    static BipSizeData bipsizedata;
    static Vector3[] bipScale = new Vector3[15];
    static Vector3[] bipPos = new Vector3[15];
    static List<List<Transform>> boneType = new List<List<Transform>>();
    public static List<Transform> BoneGroupFind(Transform[] all,string boneName,SkinnedMeshRenderer playerSkin){
        List<Transform> bones = new List<Transform>();
        for (int i = 0; i < all.Length; i++){
            if (all[i].name.Contains(boneName)){
                bones.Add(playerSkin.bones[i]);
            }
        }
        return bones;
    }
    public static void ChangeBipChildrenNode(){
        for (int i = 0; i < 15; i++){
            for (int j = 0; j < boneType[i].Count; j++){
                boneType[i][j].localScale = new Vector3(1, (1 + bipScale[i].y), (1 + bipScale[i].z));
                if(boneType[i].Count > 1){
                     if (j<boneType[i].Count/2){
                          boneType[i][j].localPosition = boneType[i][j].worldToLocalMatrix * bipPos[i];
                     }
                     else{
                          Vector3 Mpos =  new Vector3(-bipPos[i].x, bipPos[i].y, bipPos[i].z);
                          boneType[i][j].localPosition = boneType[i][j].worldToLocalMatrix * Mpos;
                     }
                }
                else{
                    boneType[i][0].localPosition = boneType[i][0].worldToLocalMatrix * bipPos[i];
                }
            }
        }
    }
    public static void CreatBipChildrenNode(Transform[] allbones,Vector3 PlayeLocalScale,List<Transform> BoneChildrenNode){
        for (int i = 0; i < allbones.Length; i++){
            GameObject BoneAllSon = new GameObject();
            BoneAllSon.name = allbones[i].name + "Son";
            BoneAllSon.transform.position = allbones[i].position;
            BoneAllSon.transform.localScale = new Vector3(allbones[i].localScale.x*PlayeLocalScale.x,allbones[i].localScale.y*PlayeLocalScale.y,allbones[i].localScale.z*PlayeLocalScale.z);
            BoneAllSon.transform.eulerAngles = allbones[i].eulerAngles;
            BoneAllSon.transform.parent = allbones[i];           
            BoneChildrenNode.Add(BoneAllSon.transform);
        }
    }
    public static void SetBipValue(BipSizeData Value){
        bipsizedata = Value;
    }
    public static void SetBoneType(List<List<Transform>> type){
        boneType = type;
    }
    static void SetBoneSizeData_thin() {
        for (int i = 0; i < 15; i++){
            bipScale[i] = new Vector3(0,bipsizedata.bipThinY[i],bipsizedata.bipThinZ[i]);
            bipPos[i] = bipsizedata.bipThinPos[i];
        }
    }
    static void SetBoneSizeData_fat() {
        for (int i = 0; i < 15; i++){
            bipScale[i] = new Vector3(0,bipsizedata.bipFatY[i],bipsizedata.bipFatZ[i]);
            bipPos[i] = bipsizedata.bipFatPos[i];
        }
    }
    static void SetBoneSizeData_strong() {
        for (int i = 0; i < 15; i++){
            bipScale[i] = new Vector3(0,bipsizedata.bipStrongY[i],bipsizedata.bipStrongZ[i]);
            bipPos[i] = bipsizedata.bipStrongPos[i];
        }
    }
    static void SetBoneSizeData_normal() {
        for (int i = 0; i < 15; i++){
            bipScale[i] = Vector3.zero;
            bipPos[i] = Vector3.zero;
        }
    }
    public static void ChangeToThin(){
        SetBoneSizeData_thin();
        ChangeBipChildrenNode();
    }
    public static void ChangeToStrong(){
        SetBoneSizeData_strong();
        ChangeBipChildrenNode();
    }
    public static void ChangeToFat(){
        SetBoneSizeData_fat();
        ChangeBipChildrenNode();
    }
    public static void ChangeToNormal(){
        SetBoneSizeData_normal();
        ChangeBipChildrenNode();
    }
}
