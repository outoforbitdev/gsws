using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour {
    void Awake() {

    }
    void Start() {

    }
    void Update() {

    }
    public void SaveGame() {
        string saveName = "TestSave";
        string directory = Application.persistentDataPath + "/Data/Saves/" + saveName + "/";
        Directory.CreateDirectory(directory);

        Game.DB.Save(directory);
    }
}