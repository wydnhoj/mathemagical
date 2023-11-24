using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamathBoard : MonoBehaviour
{
    public Piece[,] pieces = new Piece[8,8];
    public GameObject whitePiecePrefab;
    public GameObject blackPiecePrefab;

    private void Start() {
        GenerateBoard();    
    }

    private void GenerateBoard(){

        //white team

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 8; x+=2)
            {
                GeneratePiece(x,y);
            }
        }
    }

    private void GeneratePiece(int x, int y)
    {
        GameObject go = Instantiate(whitePiecePrefab) as GameObject;
        go.transform.SetParent(transform);
        Piece p = go.GetComponent<Piece>();
        pieces[x,y] = p;
    }
}
