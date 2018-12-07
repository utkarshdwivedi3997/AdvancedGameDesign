using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGeneration : MonoBehaviour {

    public bool isBase;
    public bool isHead;

    MeshFilter filter;
    MeshRenderer rend;
    MeshCollider mCollider;
    public Material mat;

	void Start () {
        // Utkarsh: Added null checks because the errors were hiding all my debugs lol
        if (gameObject.GetComponent<MeshFilter>() == null)
        {
            filter = gameObject.AddComponent<MeshFilter>();
        }
        else
        {
            filter = gameObject.GetComponent<MeshFilter>();
        }

        if (gameObject.GetComponent<MeshRenderer>() == null)
        {
            rend = gameObject.AddComponent<MeshRenderer>();
        }
        else
        {
            rend = gameObject.GetComponent<MeshRenderer>();
        }

        if (isBase == true)
        {
            CreateTargetBase();
        }
        else if (isHead == true)
        {
            CreateTargetHead();
        }

        mCollider = gameObject.AddComponent<MeshCollider>();
        mCollider.convex = true;

    }

    public void CreateTargetBase()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(0, 0, 0),//0
            new Vector3(1, 0, 0),//1
            new Vector3(1, 0, 1),//2
            new Vector3(0, 0, 1),//3
            new Vector3(1, 0, -1),//4
            new Vector3(0, 0, -1),//5
            new Vector3(-1, 0, 0),//6
            new Vector3(-1, 0, 1),//7
            new Vector3(2, 0, 0),//8
            new Vector3(2, 0, 1),//9
            new Vector3(1, 0, 2),//10
            new Vector3(0, 0, 2),//11

            new Vector3(0, -1, 0),//12
            new Vector3(1, -1, 0),//13
            new Vector3(1, -1, 1),//14
            new Vector3(0, -1, 1),//15
            new Vector3(1, -1, -1),//16
            new Vector3(0, -1, -1),//17
            new Vector3(-1, -1, 0),//18
            new Vector3(-1, -1, 1),//19
            new Vector3(2, -1, 0),//20
            new Vector3(2, -1, 1),//21
            new Vector3(1, -1, 2),//22
            new Vector3(0, -1, 2),//23

            new Vector3(0, 1, 0),//24
            new Vector3(1, 1, 0),//25
            new Vector3(1, 1, 1),//26
            new Vector3(0, 1, 1),//27

            new Vector3(0, 2, 0),//28
            new Vector3(1, 2, 0),//29
            new Vector3(1, 2, 1),//30
            new Vector3(0, 2, 1),//31
        };

        int[] tris = new int[]
        {
            //Start: Generate Base
            0, 6, 3,
            6, 7, 3,
            0, 1, 5,
            1, 4, 5,
            0, 5, 6,
            1, 2, 8,
            8, 2, 9,
            1, 8, 4,
            3, 11, 2,
            11, 10, 2,
            3, 7, 11,
            2, 10, 9,

            6, 18, 7,
            18, 19, 7,
            6, 5, 18,
            18, 5, 17,
            5, 4, 17,
            4, 16, 17,
            4, 8, 16,
            8, 20, 16,
            8, 9, 20,
            9, 21, 20,
            9, 10, 21,
            10, 22, 21,
            10, 11, 22,
            11, 23, 22,
            11, 7, 23,
            7, 19, 23,
            //End: Generate Base

            //Start: Generate Neck
            27, 24, 3,
            24, 0, 3,
            24, 25, 0,
            25, 1, 0,
            25, 26, 1,
            26, 2, 1,
            26, 27, 2,
            27, 3, 2,

            31, 28, 27,
            28, 24, 27,
            28, 29, 24,
            29, 25, 24,
            29, 30, 25,
            30, 26, 25,
            30, 31, 26,
            31, 27, 26,

            28, 30, 29,
            28, 31, 30
            //End: Generate Neck
        };
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < verts.Count; i++)
        {
            uvs.Add(new Vector2(verts[i].x, verts[i].y));
        }

        filter.mesh.SetVertices(verts);
        filter.mesh.SetTriangles(tris, 0);
        filter.mesh.SetUVs(0, uvs);
        rend.material = mat;
    }

    public void CreateTargetHead()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(0, 3, 0),//0
            new Vector3(1, 3, 0),//1
            new Vector3(-1, 3, 0),//2
            new Vector3(2, 3, 0),//3
            new Vector3(1, 3, 1),//4
            new Vector3(0, 3, 1),//5
            new Vector3(-1, 3, 1),//6
            new Vector3(2, 3, 1),//7

            new Vector3(0, 4, 0),//8
            new Vector3(1, 4, 0),//9
            new Vector3(-1, 4, 0),//10
            new Vector3(2, 4, 0),//11
            new Vector3(1, 4, 1),//12
            new Vector3(0, 4, 1),//13
            new Vector3(-1, 4, 1),//14
            new Vector3(2, 4, 1),//15
            
            new Vector3(0, 5, 0),//16
            new Vector3(1, 5, 0),//17
            new Vector3(1, 5, 1),//18
            new Vector3(0, 5, 1),//19

            new Vector3(0, 2, 0),//20
            new Vector3(1, 2, 0),//21
            new Vector3(1, 2, 1),//22
            new Vector3(0, 2, 1)//23
        };

        int[] tris = new int[]
        {
            //Start: Generate Target
            1, 21, 0,
            0, 21, 20,
            9, 1, 8,
            8, 1, 0,
            8, 0, 10,
            10, 0, 2,
            11, 3, 9,
            9, 3, 1,
            17, 9, 16,
            16, 9, 8,
            0, 20, 2,
            1, 3, 21,
            9, 17, 11,
            8, 10, 16,

            4, 5, 22,
            5, 23, 22,
            12, 13, 4,
            13, 5, 4,
            13, 14, 5,
            14, 6, 5,
            15, 12, 7,
            12, 4, 7,
            18, 19, 12,
            19, 13, 12,
            23, 5, 6,
            4, 22, 7,
            12, 15, 18,
            13, 19, 14,

            7, 22, 3,
            3, 22, 21,
            15, 7, 11,
            11, 7, 3,
            18, 15, 17,
            17, 15, 11,
            19, 18, 16,
            16, 18, 17,
            14, 19, 10,
            10, 19, 16,
            6, 14, 2,
            2, 14, 10,
            23, 6, 20,
            20, 6, 2,

            20, 21, 22,
            22, 23, 20
            //End: Generate Target
        };
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < verts.Count; i++)
        {
            uvs.Add(new Vector2(verts[i].x, verts[i].y));
        }

        filter.mesh.SetVertices(verts);
        filter.mesh.SetTriangles(tris, 0);
        filter.mesh.SetUVs(0, uvs);
        rend.material = mat;
    }

}
