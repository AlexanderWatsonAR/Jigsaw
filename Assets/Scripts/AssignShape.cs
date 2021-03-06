﻿using UnityEngine;

public class AssignShape : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Piece;
    public Mesh[] Models;
    public GameObject Board;

    // Use this for initialization
    void Start()
    {
        Mesh model = Models[ShapesLoadData.ModelArrayIndex];
        gameObject.GetComponent<MeshFilter>().sharedMesh = model;
        string tag = model.name;
        tag = tag.Remove(0, tag.LastIndexOf('_') + 1);
        gameObject.tag = tag;
        Parent.tag = tag;

        Piece.GetComponent<MeshFilter>().sharedMesh = model;
        Piece.GetComponent<MeshRenderer>().material = new Material(Board.GetComponent<MeshRenderer>().material);
        Piece.tag = tag;
    }
}
