using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShardGenerate : MonoBehaviour {

    public bool bShard;
    public bool blShard;
    public bool lShard;
    public bool tlShard;
    public bool tShard;
    public bool trShard;
    public bool rShard;
    public bool brShard;

    MeshFilter filter;
    MeshRenderer rend;
    MeshCollider mCollider;
    public Material mat;
    public Rigidbody rb;
    public float speed;

    void Start () {
        

        filter = gameObject.AddComponent<MeshFilter>();
        rend = gameObject.AddComponent<MeshRenderer>();

        rb = GetComponent<Rigidbody>();
        if (bShard == true)
        {
            CreateBottomShard();
            rb.AddForce(transform.up * -speed);
        }
        else if (blShard == true)
        {
            CreateBottomLeftShard();
            rb.AddForce(transform.right * -speed);
            rb.AddForce(transform.up * -speed);
        }
        else if (lShard == true)
        {
            CreateLeftShard();
            rb.AddForce(transform.right * -speed);
        }
        else if (tlShard == true)
        {
            CreateTopLeftShard();
            rb.AddForce(transform.right * -speed);
            rb.AddForce(transform.up * speed);
        }
        else if (tShard == true)
        {
            CreateTopShard();
            rb.AddForce(transform.up * speed);
        }
        else if (trShard == true)
        {
            CreateTopRightShard();
            rb.AddForce(transform.right * speed);
            rb.AddForce(transform.up * speed);
        }
        else if (rShard == true)
        {
            CreateRightShard();
            rb.AddForce(transform.right * speed);
        }
        else if (brShard == true)
        {
            CreateBottomRightShard();
            rb.AddForce(transform.right * speed);
            rb.AddForce(transform.up * -speed);
        }

        mCollider = gameObject.AddComponent<MeshCollider>() as MeshCollider;
        mCollider.convex = true;
        Destroy(this.gameObject, 10);
    }

    void Update ()
    {
        
    }

    public void CreateBottomShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(0, 2, 0),//0
            new Vector3(1, 2, 0),//1
            new Vector3(1, 2, 1),//2
            new Vector3(0, 2, 1),//3
            new Vector3(0.5f, 3.5f, 0f),//4
            new Vector3(0.5f, 3.5f, 1f)//5
        };

        int[] tris = new int[]
        {
            0, 4, 1,
            4, 0, 5,
            5, 0, 3,
            3, 2, 5,
            5, 2, 4,
            4, 2, 1,
            0, 1, 2,
            0, 2, 3
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

    public void CreateBottomLeftShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(-1, 3, 0),//0
            new Vector3(0, 2, 0),//1
            new Vector3(0, 2, 1),//3
            new Vector3(-1, 3, 1),//2
            new Vector3(0.5f, 3.5f, 0f),//4
            new Vector3(0.5f, 3.5f, 1f)//5
        };

        int[] tris = new int[]
        {
            0, 4, 1,
            4, 0, 5,
            5, 0, 3,
            3, 2, 5,
            5, 2, 4,
            4, 2, 1,
            0, 1, 2,
            0, 2, 3
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

    public void CreateLeftShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(-1, 4, 0),//0
            new Vector3(-1, 3, 0),//1
            new Vector3(-1, 3, 1),//2
            new Vector3(-1, 4, 1),//3
            new Vector3(0.5f, 3.5f, 0f),//4
            new Vector3(0.5f, 3.5f, 1f)//5
        };

        int[] tris = new int[]
        {
            0, 4, 1,
            4, 0, 5,
            5, 0, 3,
            3, 2, 5,
            5, 2, 4,
            4, 2, 1,
            0, 1, 2,
            0, 2, 3
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

    public void CreateTopLeftShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(0, 5, 0),//0
            new Vector3(-1, 4, 0),//1
            new Vector3(-1, 4, 1),//2
            new Vector3(0, 5, 1),//3
            new Vector3(0.5f, 3.5f, 0f),//4
            new Vector3(0.5f, 3.5f, 1f)//5
        };

        int[] tris = new int[]
        {
            0, 4, 1,
            4, 0, 5,
            5, 0, 3,
            3, 2, 5,
            5, 2, 4,
            4, 2, 1,
            0, 1, 2,
            0, 2, 3
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

    public void CreateTopShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(1, 5, 0),//0
            new Vector3(0, 5, 0),//1
            new Vector3(0, 5, 1),//2
            new Vector3(1, 5, 1),//3
            new Vector3(0.5f, 3.5f, 0f),//4
            new Vector3(0.5f, 3.5f, 1f)//5
        };

        int[] tris = new int[]
        {
            0, 4, 1,
            4, 0, 5,
            5, 0, 3,
            3, 2, 5,
            5, 2, 4,
            4, 2, 1,
            0, 1, 2,
            0, 2, 3
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

    public void CreateTopRightShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(2, 4, 0),//0
            new Vector3(1, 5, 0),//1
            new Vector3(1, 5, 1),//2
            new Vector3(2, 4, 1),//3
            new Vector3(0.5f, 3.5f, 0f),//4
            new Vector3(0.5f, 3.5f, 1f)//5
        };

        int[] tris = new int[]
        {
            0, 4, 1,
            4, 0, 5,
            5, 0, 3,
            3, 2, 5,
            5, 2, 4,
            4, 2, 1,
            0, 1, 2,
            0, 2, 3
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

    public void CreateRightShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
        {
            new Vector3(2, 3, 0),//0
            new Vector3(2, 4, 0),//1
            new Vector3(2, 4, 1),//2
            new Vector3(2, 3, 1),//3
            new Vector3(0.5f, 3.5f, 0f),//4
            new Vector3(0.5f, 3.5f, 1f)//5
        };

        int[] tris = new int[]
        {
            0, 4, 1,
            4, 0, 5,
            5, 0, 3,
            3, 2, 5,
            5, 2, 4,
            4, 2, 1,
            0, 1, 2,
            0, 2, 3
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

    public void CreateBottomRightShard()
    {
        Debug.Log("Generating...");
        Mesh mesh = filter.mesh;
        List<Vector3> verts = new List<Vector3>
            {
                new Vector3(1, 2, 0),//0
                new Vector3(2, 3, 0),//1
                new Vector3(2, 3, 1),//2
                new Vector3(1, 2, 1),//3
                new Vector3(0.5f, 3.5f, 0f),//4
                new Vector3(0.5f, 3.5f, 1f)//5
            };

        int[] tris = new int[]
        {
                0, 4, 1,
                4, 0, 5,
                5, 0, 3,
                3, 2, 5,
                5, 2, 4,
                4, 2, 1,
                0, 1, 2,
                0, 2, 3
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
