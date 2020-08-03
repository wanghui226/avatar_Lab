using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace MileCode {
    [DisallowMultipleComponent]
    public class AvatarDeformer : MonoBehaviour {
        public AvatarDeformData avatarDeformData;
        public SkinnedMeshRenderer[] skinnedMeshRenderers;
        public Transform playerTransform;
        private void Start() {
            // check 
            if(IsAvatarInfoReady()) {
                AvatarDeformController.InitializeController(playerTransform, avatarDeformData, skinnedMeshRenderers);
            }
        }

        public bool IsAvatarInfoReady() {
            if(this.avatarDeformData == null) {
                Debug.Log("AvatarDeformData is not ready.");
                return false;
            }

            // check skinnedMesh
            if(true) { 
            }

            // check transform
            if(true) { 
            }

            //Debug.Log("AvatarInfo is ready.");
            return true;
        }

        private void OnGUI() {
            if(GUILayout.Button("Normal")) {
                AvatarDeformController.DeformToNormal();
            }
        }

    }
}
