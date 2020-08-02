using System.Collections;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

namespace MileCode {
    [CustomEditor(typeof(AvatarDeformer))]
    public class AvatarDeformEditor : Editor {
        FieldInfo[] allFields;

        private void OnEnable() {
            this.allFields = this.FetchAllFieldFromAvatarDeformData();
        }


        void OnSceneGUI() {
            AvatarDeformer avatarInfo = target as AvatarDeformer;
            if(avatarInfo.IsAvatarInfoReady() && this.allFields.Length >= 1) {
                this.DrawAvatarDefromDataOnScreen(avatarInfo.avatarDeformData);
            }

        }


        FieldInfo[] FetchAllFieldFromAvatarDeformData() {
            FieldInfo[] allfield = typeof(AvatarDeformData).GetFields();
            if(allfield.Length >= 1) {
                return allfield;
            }
            return null;
        }

        Vector2 pos = new Vector2(10, 10);
        bool isSettingUIShowing = false;
        string settingUIName = "";
        private void DrawAvatarDefromDataOnScreen(AvatarDeformData avatarDeformData) {
            Handles.BeginGUI();
            {
                GUIStyle boxStyle = new GUIStyle("box");
                GUILayout.BeginArea(new Rect(Screen.width - 300, Screen.height - 440, 295, 390), boxStyle);
                {
                    GUILayout.Label("-------------- AvatarDeformData ---------------");
                    using(var scrollView = new GUILayout.ScrollViewScope(this.pos)) {
                        this.pos = scrollView.scrollPosition;

                        foreach(var field in this.allFields) {
                            
                            GUILayout.BeginHorizontal();
                            GUILayout.Label(field.Name);
                            if(field.Name == "dataName" || field.Name == "dataID") {
                                GUILayout.EndHorizontal();
                                continue;
                            }
                            if(GUILayout.Button("Set", GUILayout.Width(40))) {
                                this.isSettingUIShowing = true;
                                settingUIName = field.Name;
                            }
                            GUILayout.EndHorizontal();
                            if(isSettingUIShowing && field.Name == settingUIName) {

                                this.DrawSettingUI(field, avatarDeformData);
                            }
                        }
               
                    }
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }

        Vector3[] FieldValue;
        private void DrawSettingUI(FieldInfo field, AvatarDeformData avatarDeformData) {
            this.FieldValue = GetFieldValueByFieldName(field, avatarDeformData);
            if(FieldValue == null) {
                return;
            }
            // position settings
            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
            // rotation settings;
            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
            // scale settings
            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
        }

        private Vector3[] GetFieldValueByFieldName(FieldInfo field, AvatarDeformData avatarDeformData) {
            switch(field.Name) {
                case "head":
                    return avatarDeformData.head;
                case "neck":
                    return avatarDeformData.head;
                case "spine2":
                    return avatarDeformData.head;
                case "spine1":
                    return avatarDeformData.head;
                case "spine":
                    return avatarDeformData.head;
                case "pelvis":
                    return avatarDeformData.head;
                case "thigh":
                    return avatarDeformData.head;
                case "calf":
                    return avatarDeformData.head;
                case "clavicle":
                    return avatarDeformData.head;
                case "upperArm":
                    return avatarDeformData.head;
                case "foreArm":
                    return avatarDeformData.head;
                case "hand":
                    return avatarDeformData.head;
                case "finger":
                    return avatarDeformData.head;
                case "foot":
                    return avatarDeformData.head;
                case "toe0":
                    return avatarDeformData.head;
                default:
                    return null;
            }
        }
    }
}