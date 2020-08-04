using System.Collections;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace MileCode {
    [CustomEditor(typeof(AvatarDeformer))]
    public class AvatarDeformEditor : Editor {

        void OnSceneGUI() {
            AvatarDeformer avatarDeformer = target as AvatarDeformer;

            if(avatarDeformer.IsAvatarDeformerReady() && avatarDeformer.avatarDeformData.allFieldsValue.Count >= 1) {
                this.DrawAvatarDefromDataOnScreen(avatarDeformer.avatarDeformData);
            }

           

        }

        Vector2 pos = new Vector2(10, 10);
        bool isSettingUIShowing = false;
        string settingUIName = "";
        private void DrawAvatarDefromDataOnScreen(AvatarDeformData avatarDeformData) {
            Handles.BeginGUI();
            {
                GUIStyle boxStyle = new GUIStyle("box");
                GUILayout.BeginArea(new Rect(Screen.width - 610, Screen.height - 460, 600, 412), boxStyle);
                {
                    GUILayout.Label("-------------------------------------- AvatarDeformData ------------------------------------------");
                 
                    GUILayout.BeginHorizontal();
                    float buttonWidth = 145;
  
                    if(GUILayout.Button("Normal", GUILayout.Width(buttonWidth))) {
                        AvatarDeformData copiedValue = AssetDatabase.LoadAssetAtPath<AvatarDeformData>("Assets/Data/AvatarSizeData/AvatarDeformData_normal.asset");
                        avatarDeformData.CopyValuesFromAnotherData(copiedValue);
                    }
                    if(GUILayout.Button("Fat", GUILayout.Width(buttonWidth))) {
                        AvatarDeformData copiedValue = AssetDatabase.LoadAssetAtPath<AvatarDeformData>("Assets/Data/AvatarSizeData/AvatarDeformData_fat.asset");
                        avatarDeformData.CopyValuesFromAnotherData(copiedValue);
                    }
                    if(GUILayout.Button("Strong", GUILayout.Width(buttonWidth))) {
                        AvatarDeformData copiedValue = AssetDatabase.LoadAssetAtPath<AvatarDeformData>("Assets/Data/AvatarSizeData/AvatarDeformData_strong.asset");
                        avatarDeformData.CopyValuesFromAnotherData(copiedValue);
                    }
                    if(GUILayout.Button("Thin", GUILayout.Width(buttonWidth))) {
                        AvatarDeformData copiedValue = AssetDatabase.LoadAssetAtPath<AvatarDeformData>("Assets/Data/AvatarSizeData/AvatarDeformData_thin.asset");
                        avatarDeformData.CopyValuesFromAnotherData(copiedValue);
                    }
                    
                    GUILayout.EndHorizontal();
                    /*
                    if(GUILayout.Button("Save Current")) {
                    }
                    */
                    GUILayout.Label("--------------------------------------------------------------------------------------------------");
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Data Name: ", GUILayout.Width(70));
                    avatarDeformData.dataName = GUILayout.TextField(avatarDeformData.dataName, GUILayout.Width(175));
                    GUILayout.Label("\tData ID: ", GUILayout.Width(110));
                    avatarDeformData.dataID = EditorGUILayout.IntField(avatarDeformData.dataID, GUILayout.Width(223));
                    GUILayout.EndHorizontal();
                    using(var scrollView = new GUILayout.ScrollViewScope(this.pos)) {
                        this.pos = scrollView.scrollPosition;
                        
                        foreach(var element in avatarDeformData.allFieldsValue) {
                            GUILayout.BeginHorizontal();
                            GUILayout.Label(element.Key);
                            
                            if(element.Key == "dataName" || element.Key == "dataID") {
                                GUILayout.EndHorizontal();
                                continue;
                            }
                            
                            if(GUILayout.Button("Set", GUILayout.Width(40))) {
                                this.isSettingUIShowing = true;
                                this.settingUIName = element.Key;
                            }
                            
                            GUILayout.EndHorizontal();
                            
                            if(isSettingUIShowing && element.Key == this.settingUIName) {
                                this.DrawSettingUI(element.Key, avatarDeformData);
                            }
                            
                        }
               
                    }
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }


        private void DrawSettingUI(string fieldName, AvatarDeformData avatarDeformData) {
            // position settings
            GUILayout.BeginHorizontal();
            GUILayout.Label("    Pos: ");
            avatarDeformData.allFieldsValue[fieldName][0].x = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][0].x, -1, 1);
            avatarDeformData.allFieldsValue[fieldName][0].y = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][0].y, -1, 1);
            avatarDeformData.allFieldsValue[fieldName][0].z = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][0].z, -1, 1);
            GUILayout.EndHorizontal();
            // rotation settings;
            GUILayout.BeginHorizontal();
            GUILayout.Label("    Rot: ");
            avatarDeformData.allFieldsValue[fieldName][1].x = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][1].x, -1, 1);
            avatarDeformData.allFieldsValue[fieldName][1].y = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][1].y, -1, 1);
            avatarDeformData.allFieldsValue[fieldName][1].z = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][1].z, -1, 1);
            GUILayout.EndHorizontal();
            // scale settings
            GUILayout.BeginHorizontal();
            GUILayout.Label("    Scl: ");
            avatarDeformData.allFieldsValue[fieldName][2].x = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][2].x, -1, 1);
            avatarDeformData.allFieldsValue[fieldName][2].y = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][2].y, -1, 1);
            avatarDeformData.allFieldsValue[fieldName][2].z = EditorGUILayout.Slider(avatarDeformData.allFieldsValue[fieldName][2].z, -1, 1);
            GUILayout.EndHorizontal();
        }

    }
}