using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MileCode {
    public class AvatarDeformController  {
        static AvatarDeformData avatarDeformData;
        static List<AvatarDeformData> predefined_AvatarDeformData;

        public static void InitializeController(Transform playerTransform, AvatarDeformData playerAvatarDeformData, SkinnedMeshRenderer[] skinnedMeshRenderers) {
            avatarDeformData = playerAvatarDeformData;
            SetDefaultDeformData();
        }

        public static void Deform() { 
           
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
