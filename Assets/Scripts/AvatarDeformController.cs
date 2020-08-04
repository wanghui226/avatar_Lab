using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MileCode {
    public class AvatarDeformController  {
        static AvatarDeformData avatarDeformData;
        static List<AvatarDeformData> predefined_AvatarDeformData;
        private static List<List<Transform>> boneType = new List<List<Transform>>();
        private static string[] allBoneType = { "Pelvis", "Spine", "Spine1", "Spine2", "Thigh", "Calf", "Neck", "Head", "Clavicle", "UpperArm", "Forearm", "Hand", "Finger", "Foot", "Toe0" };
        public static void InitializeController(Vector3 playerScale, SkinnedMeshRenderer[] playerSkinnedMeshRenderers,AvatarDeformData PlayerDeformData) {
            avatarDeformData = PlayerDeformData;
            SetDefaultDeformData();
            List<Transform> InitializeBones = CreatAndReplaceController(playerSkinnedMeshRenderers,playerScale);
            //给变形控制器分组
            for(int i = 0; i < allBoneType.Length; i++) {
                boneType.Add(GroupDeformers(InitializeBones, allBoneType[i]));
            }
        }
        public static List<Transform> GroupDeformers(List<Transform> deformers,string deformersName) {
            List<Transform> bones = new List<Transform>();
            for (int i = 0; i < deformers.Count; i++){
                if (deformers[i].name.Contains(deformersName)){
                    bones.Add(deformers[i]);
                }
            }
            return bones;
        }
        private static List<Transform> CreatAndReplaceController(SkinnedMeshRenderer[] skinnedMeshRenderers,Vector3 playerScale) {
            List<Transform> InitializeBones = new List<Transform>();
            for (int i = 0; i < skinnedMeshRenderers.Length; i++){    //当前skinmesh的蒙皮网格
                List<GameObject> BoneControllerNode = new List<GameObject>();
                List<Transform> SingleSkinMeshBones = new List<Transform>();
                for (int j = 0; j < skinnedMeshRenderers[i].bones.Length; j++){
                    SingleSkinMeshBones.Add(skinnedMeshRenderers[i].bones[j]);   //当前skinmesh的蒙皮骨骼
                }
                BoneControllerNode = CreatNewController(SingleSkinMeshBones,playerScale);
                Debug.Log(BoneControllerNode.Count);

                List<Transform> ReplaceControllerTransform = new List<Transform>();
                for (int ObjCount = 0; ObjCount < BoneControllerNode.Count; ObjCount++){
                    ReplaceControllerTransform.Add(BoneControllerNode[ObjCount].transform);
                }
                skinnedMeshRenderers[i].bones = ReplaceControllerTransform.ToArray();  //替换当前skinmesh中的蒙皮骨骼

                for (int q = 0; q < BoneControllerNode.Count; q++){    //将新控制器填充进控制器池
                    InitializeBones.Add(BoneControllerNode[q].transform);
                }
            }
            return InitializeBones;  //返回替换的所有骨骼
        }
        private static List<GameObject> CreatNewController(List<Transform> OriginalBones,Vector3 playerScale){
            List<GameObject> BoneChildrenNode = new List<GameObject>();
            for (int i = 0; i < OriginalBones.Count; i++){
            GameObject NewBoneChildrenNode = new GameObject();
            NewBoneChildrenNode.name = OriginalBones[i].name + "_Controller";
            NewBoneChildrenNode.transform.position = OriginalBones[i].position;
            NewBoneChildrenNode.transform.localScale = new Vector3(OriginalBones[i].localScale.x*playerScale.x,OriginalBones[i].localScale.y*playerScale.y,OriginalBones[i].localScale.z*playerScale.z);
            NewBoneChildrenNode.transform.eulerAngles = OriginalBones[i].eulerAngles;
            NewBoneChildrenNode.transform.parent = OriginalBones[i];           
            BoneChildrenNode.Add(NewBoneChildrenNode);
            }
            return BoneChildrenNode;
        }
        public static void  Deform() {
            List<Vector3> bipScale = new List<Vector3>() ; List<Vector3> bipPos = new List<Vector3>();
            //从玩家参数里读数据
            Dictionary<string, Vector3[]> GetDeformData = avatarDeformData.allFieldsValue;
            for (int i = 0; i < GetDeformData.Keys.Count; i++){
                Vector3[] a = GetDeformData[allBoneType[i]];
                bipPos.Add(a[0]);
                bipScale.Add(a[2]);
            } 
            //将数据赋值给变形
            for (int i = 0; i < allBoneType.Length; i++){
                for (int j = 0; j < boneType[i].Count; j++){
                    boneType[i][j].localScale = new Vector3(1, (1 + bipScale[i].y), (1 + bipScale[i].z));
                    if(boneType[i].Count > 1){
                        if (j<boneType[i].Count/2){
                          boneType[i][j].localPosition = boneType[i][j].worldToLocalMatrix * bipPos[i];
                        }else{
                          Vector3 Mpos =  new Vector3(-bipPos[i].x, bipPos[i].y, bipPos[i].z);
                          boneType[i][j].localPosition = boneType[i][j].worldToLocalMatrix * Mpos;
                        }
                    }else{
                        boneType[i][0].localPosition = boneType[i][0].worldToLocalMatrix * bipPos[i];
                    }
                }
            }
        }
        public static void DeformToFat() {
            AvatarDeformData sourceData = predefined_AvatarDeformData[0];
            avatarDeformData.CopyValuesFromAnotherData(sourceData);
        //    Deform(sourceData);
        }
        public static void DeformToNormal() {
            AvatarDeformData sourceData = predefined_AvatarDeformData[1];
            avatarDeformData.CopyValuesFromAnotherData(sourceData);
        //    Deform(sourceData);
        }
        public static void DeformToStrong() {
            AvatarDeformData sourceData = predefined_AvatarDeformData[2];
            avatarDeformData.CopyValuesFromAnotherData(sourceData);
        //    Deform(sourceData);
        }
        public static void DeformToThin() {
            AvatarDeformData sourceData = predefined_AvatarDeformData[0];
            avatarDeformData.CopyValuesFromAnotherData(sourceData);
        //    Deform(sourceData);
        }
        private static void SetDefaultDeformData() {
            string bundleAssetPath = Application.dataPath + "/AssetBundles/StandaloneWindows/predefinedavatarsize";
            var bundleData = AssetBundle.LoadFromFile(bundleAssetPath);
            if(bundleData == null) {
                Debug.Log("Faild to load predfinedAvatarSizeData bundle");
                return;
            }
            var prefab = bundleData.LoadAsset<GameObject>("Predefined_AvatarSize");
            if(prefab == null) {
                Debug.Log("Can't find object in bundle data.");
                return;
            }
            AvatarDeformDataPool predfinedData = prefab.GetComponent<AvatarDeformDataPool>();
            if(predfinedData == null) {
                Debug.Log("Can't find component in prefab.");
            }
            if(predfinedData.avatarDeformDatas.Length >= 1) {
                predefined_AvatarDeformData = new List<AvatarDeformData>();
                foreach(AvatarDeformData data in predfinedData.avatarDeformDatas) {
                    if(data != null) { 
                        predefined_AvatarDeformData.Add(data);
                    }
                }
            }
        }
    }
}
