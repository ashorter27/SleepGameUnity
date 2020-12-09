using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueTree dialogue;
    public UnityEvent RestoreSanityByTalk;

   


    // Called automatically by unity when a rigid body intersects a collider with "isTrigger" checked.
    public void OnTriggerEnter(Collider other){
        RestoreSanityByTalk.Invoke();
        dialogueManager.StartDialog(dialogue);
    }
}
