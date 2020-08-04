using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MileCode {
    [DisallowMultipleComponent]
    public class AvatarDeformer : MonoBehaviour {
        public AvatarDeformData avatarDeformData;
        public SkinnedMeshRenderer[] skinnedMeshRenderers;
        public Transform playerScale;
        private void Start() {
            // check 
            if(IsAvatarDeformerReady()) {
                AvatarDeformController.InitializeController(playerScale.localScale, skinnedMeshRenderers,avatarDeformData);
            }
        }
        private void Update() {
            if(IsAvatarDeformerReady()) {
                AvatarDeformController.Deform();
            }
        }

        public bool IsAvatarDeformerReady() {
            if(this.avatarDeformData == null) {
                Debug.Log("AvatarDeformData is not ready.");
                return false;
            }

            // check skinnedMesh
            if(skinnedMeshRenderers.Length <= 1) {
                Debug.Log("SkinnedMeshRenderer is not ready.");
                return false;
            } else {
                foreach(var skinnedMesh in skinnedMeshRenderers) {
                    if(skinnedMesh == null) {
                        Debug.Log("There's one skinnedMesh not ready.");
                        return false;
                    }
                }
            }

            // check playerScale
            if(playerScale == null) {
                Debug.Log("Player transform is not ready.");
                return false;
            }

            //Debug.Log("AvatarInfo is ready.");
            return true;
        }

    }
}
