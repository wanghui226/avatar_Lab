using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGUI : MonoBehaviour{
    void OnGUI(){
        float buttonWidth = Screen.width/8;
        float buttonHeight = Screen.height/8;
        if (GUI.Button(new Rect(buttonWidth * 6,buttonHeight,buttonWidth,buttonHeight),"瘦")){
          //  ChangeBone.ChangeToThin(); 
            BoneScale.ChangeToThin(); 
        }
        if (GUI.Button(new Rect(buttonWidth * 6,buttonHeight *2+buttonHeight/5,buttonWidth,buttonHeight),"胖")){
          //  ChangeBone.ChangeToFat();
            BoneScale.ChangeToFat();
        }
        if (GUI.Button(new Rect(buttonWidth * 6,buttonHeight *3+buttonHeight/5*2,buttonWidth,buttonHeight),"精壮")){            
           // ChangeBone.ChangeToStrong();
            BoneScale.ChangeToStrong();
        }
        if (GUI.Button(new Rect(buttonWidth * 6,buttonHeight *4+buttonHeight/5*3,buttonWidth,buttonHeight),"标准")){
           // ChangeBone.ChangeToNormal();
            BoneScale.ChangeToNormal();
        }    
    }
}
