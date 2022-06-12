using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tracery;
using TMPro;

public class Generator : MonoBehaviour
{
    public GameObject go;
    public string expanded;
    public TMP_Text text;
    Grammar grammar;



    void Start()
    {

        //   grammar = go.GetComponent<TraceryGrammar>().Grammar;
        LoadJSON();
        Regenerate();

    }

    void LoadJSON()
    {
        TextAsset jsonFile = Resources.Load("grammer") as TextAsset; // assuming the file is at Assets/Resources/grammar.json
         grammar = Grammar.LoadFromJSON(jsonFile);
        Debug.Log(grammar.ToString());
    }

    // Update is called once per frame
    public void Regenerate()
    {
         expanded = grammar.Flatten("#origin#");
        text.text = expanded;
    }
}
