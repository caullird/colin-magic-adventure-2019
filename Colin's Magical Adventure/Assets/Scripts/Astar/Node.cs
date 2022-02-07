using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int gridX; // position X dans le tableau de noeuds
    public int gridY; // position Y dans le tableau de noeuds


    public bool IsWall; // dit si le noeud est obstrué ou non
    public Vector3 Position;

    public Node Parent; // pour A*, récupère le noeud précedent pour retracer le chemin le plus court

    public int gCost; // coût pour aller au prochain noeud
    public int hCost; // distance entre le noeud et la destination

    public int FCost { get { return gCost + hCost; } } // gCost + hCost

    public Node(bool a_IsWall, Vector3 a_pos, int a_grdX, int a_gridY) 
    {
        IsWall = a_IsWall; // dit si le noeud est obstrué ou non
        Position = a_pos; 
        gridX = a_grdX; // position X dans le tableau de noeuds
        gridY = a_gridY; // position Y dans le tableau de noeuds
    }
}
