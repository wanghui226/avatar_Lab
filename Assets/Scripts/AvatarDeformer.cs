using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MileCode {
    [DisallowMultipleComponent]
    public class AvatarDeformer : MonoBehaviour {
        public SkinnedMeshRenderer[] skinnedMeshRenderers;
        public AvatarDeformData avatarDeformData;
        private void Start() {
            if(IsAvatarInfoReady()) {
            }
        }

        public bool IsAvatarInfoReady() {
            if(this.avatarDeformData == null) {
                Debug.Log("AvatarDeformData is not ready.");
                return false;
            }

            if(this.skinnedMeshRenderers.Length >= 1) {
                foreach(var skinnedMeshRenderer in this.skinnedMeshRenderers) {
                    if(skinnedMeshRenderer == null) {
                        Debug.Log("SkinnedMeshRenderer is not ready.");
                        return false;
                    }
                }
            } else {
                Debug.Log("SkinnedMeshRenderer is not ready.");
                return false;
            }
            
            //Debug.Log("AvatarInfo is ready.");
            return true;
        }

        

    }
}
