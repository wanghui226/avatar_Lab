using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MileCode {
    public class AvatarDeformController  {
        static List<Transform> deformers;
        static AvatarDeformData avatarDeformData;

        public static void InitializeController(Transform playerTransform, AvatarDeformData avatarDeformDataInput, SkinnedMeshRenderer[] skinnedMeshRenderer) {
            avatarDeformData = avatarDeformDataInput;
            deformers = GetDeformersFromDeformNodes();
            GroupDeformers(deformers);
        }

        public static void GroupDeformers(List<Transform> deformers) {

        }

        private static List<Transform> GetDeformersFromDeformNodes() {
            List<Transform> deformers = new List<Transform>();
            return deformers;
        }

        

        public static void DeformToFat() {
            AvatarDeformData sourceData = GetDeformDataFromPedefined(AvatarSize.fat);
            avatarDeformData.CopyValuesFromAnotherData(sourceData);
            Deform();
        }


        public static void DeformToNormal() {
            AvatarDeformData sourceData = GetDeformDataFromPedefined(AvatarSize.normal);
            avatarDeformData.CopyValuesFromAnotherData(sourceData);
            Deform();
        }

        private static void  Deform() { 
        }

      


        private static AvatarDeformData GetDeformDataFromPedefined(AvatarSize avatarSize) {
            return null;
            //return AssetBundle.LoadFromFile("path").LoadAsset<AvatarDeformData>("predefined_AvatarSize");
        }


        enum AvatarSize { 
            normal,
            fat,
            strong,
            thin
        }

    }
}
