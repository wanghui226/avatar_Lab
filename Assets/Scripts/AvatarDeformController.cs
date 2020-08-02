using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MileCode {
    public class AvatarDeformController  {
        static SkinnedMeshRenderer[] skinnedMeshRenderers;
        static Transform[] deformNodes;
        static List<GameObject> deformers;
        public static void InitializeAvatarSizeController(SkinnedMeshRenderer[] skinnedMeshesRendererComponents, Transform[] deformNodeTranforms) {
            deformNodes = deformNodeTranforms;
            skinnedMeshRenderers = skinnedMeshesRendererComponents;
            deformers = GetDeformersFromDeformNodes();

        }

        private static void EnableDeformers(List<GameObject> deformers) {
            throw new NotImplementedException();
        }

        private static List<GameObject> GetDeformersFromDeformNodes() {
            List<GameObject> deformers = new List<GameObject>();
            foreach(Transform deformNode in deformNodes) {
                GameObject deformer = new GameObject(deformNode.name + "_def");
                deformer.transform.SetParent(deformNode);
                deformer.transform.localPosition = Vector3.zero;
                deformer.transform.localRotation = Quaternion.Euler(Vector3.zero);
                deformer.transform.localScale = Vector3.one;
                //deformer.transform.position = deformNode.transform.position;
            }
            return deformers;
        }

        public static void Deform() { 
            
        }

    }
}
