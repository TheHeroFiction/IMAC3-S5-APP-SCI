using UnityEngine;
using System.Collections;
using System;

public class Diamond_Square_Script : MonoBehaviour
{
    public int nb_divisions;
    public float size;
    public float height;

    Vector3[] vertex_array;
    int vertex_count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateTerrain();
    }
    void CreateTerrain()
    {
        vertex_count = (nb_divisions+1) * (nb_divisions+1);
        vertex_array = new Vector3[vertex_count];
        Vector2[] uvs = new Vector2[vertex_count];
        int[] triangles = new int[nb_divisions*nb_divisions*6];

        float half_size = size * 0.5f;
        float division_size = size/nb_divisions;

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        int triangle_offset = 0;

        for (int i = 0; i <= nb_divisions;i++ )
        {
            for (int j = 0; j <= nb_divisions; j++)
            {
                vertex_array[i * (nb_divisions+1) +j ] = new Vector3(-half_size+j*division_size,0.0f,half_size-i*division_size);
                uvs[i * (nb_divisions+1) + j] = new Vector2((float)i/nb_divisions, (float)j/nb_divisions);

                if ( i < nb_divisions && j < nb_divisions)
                {
                    int top_left = i * (nb_divisions+1) +j;
                    int bot_left = (i+1) * (nb_divisions+1) + j;

                    triangles[triangle_offset] = top_left;
                    triangles[triangle_offset+1] = top_left+1;
                    triangles[triangle_offset+2] = bot_left+1;

                    triangles[triangle_offset+3] = top_left;
                    triangles[triangle_offset+4] = bot_left+1;
                    triangles[triangle_offset+5] = bot_left;

                    triangle_offset += 6;
                }
            }
        }

        vertex_array[0].y = UnityEngine.Random.Range(-height, height);
        vertex_array[nb_divisions].y = UnityEngine.Random.Range(-height, height);
        vertex_array[vertex_array.Length - 1].y = UnityEngine.Random.Range(-height, height);
        vertex_array[vertex_array.Length - 1 - nb_divisions].y = UnityEngine.Random.Range(-height, height);

        int iterations = (int)Math.Log(nb_divisions,2);
        int num_square = 1;
        int square_size = nb_divisions;

        for (int i = 0; i < iterations; i++)
        {
            int row = 0;
            for (int j = 0; j < num_square; j++)
            {
                int col = 0;
                for (int k = 0; k < num_square; k++)
                {
                    DiamondSquare(row,col,square_size,height);
                    col+= square_size;
                }
                row += square_size;
            }
            num_square *= 2;
            square_size /= 2;
            height *= 0.5f;
        }


        mesh.vertices = vertex_array;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    void DiamondSquare(int row, int col, int size, float offset)
    {
        int half_size = (int)(size*0.5f);
        int top_left = row * (nb_divisions+1) + col;
        int bot_left = (row + size) * (nb_divisions+1) + col;

        int mid = (int)(row+half_size) * (nb_divisions + 1) + (int) (col + half_size);
        vertex_array[mid].y = (vertex_array[top_left].y + vertex_array[top_left +size].y + vertex_array[bot_left].y + vertex_array[bot_left+size].y) * 0.25f + UnityEngine.Random.Range(-offset,offset);

        vertex_array[top_left+half_size].y = (vertex_array[top_left].y + vertex_array[top_left+size].y + vertex_array[mid].y)/3 + UnityEngine.Random.Range(-offset,offset);
        vertex_array[mid-half_size].y = (vertex_array[top_left].y + vertex_array[bot_left].y + vertex_array[mid].y)/3 + UnityEngine.Random.Range(-offset,offset);
        vertex_array[mid+half_size].y = (vertex_array[top_left+size].y + vertex_array[bot_left+size].y + vertex_array[mid].y)/3 + UnityEngine.Random.Range(-offset,offset);
        vertex_array[bot_left+half_size].y = (vertex_array[bot_left].y + vertex_array[bot_left+size].y + vertex_array[mid].y)/3 + UnityEngine.Random.Range(-offset,offset);

    }
}
