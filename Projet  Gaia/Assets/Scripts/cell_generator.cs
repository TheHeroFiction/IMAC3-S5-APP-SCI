using UnityEngine;
using System.Collections.Generic;

public class cell_generator : MonoBehaviour
{
    public GameObject cell;
    
    // used to create a field of 2*dimension x dimension cells
    public int dimension; 
    public int ratio_width_height;

    public Transform parent;

    public Camera cam;
    public List<GameObject> cells;
    public List<GameObject> cells_previous_state;

    private float waitTime = 2.0f;
    private float timer = 0.0f;

    void Game_of_life()
    {
        cells_previous_state = cells;
        for (int i = 0; i < cells.Count; i++)
        {
            int neighbourghs = 0;

            if (i == 0)
            {//for bottom left corner
                if (cells_previous_state[i + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + ratio_width_height*dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                if (cells_previous_state[i + ratio_width_height*dimension*dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int bot_left = 0; bot_left < 2; bot_left++)
                {
                    if (cells_previous_state[i + (ratio_width_height*dimension-1)*dimension + bot_left].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
            }
            else if (i == dimension-1)
            {//for top left corner
                if (cells_previous_state[i + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                
                if (cells_previous_state[i + (ratio_width_height*dimension-2)*dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int top_left = -1; top_left < 1; top_left++)
                {
                    if (cells_previous_state[i + (ratio_width_height*dimension-1)*dimension + top_left].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
            }
            else if (i == dimension*(ratio_width_height*dimension-1))
            {//for bottom right corner
                if (cells_previous_state[i + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                
                if (cells_previous_state[i - (ratio_width_height*dimension-2)*dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int bot_right = 0; bot_right < 2; bot_right++)
                {
                    if (cells_previous_state[i - (ratio_width_height*dimension-1)*dimension + bot_right].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
            }
            else if (i == dimension*ratio_width_height*dimension-1)
            {//for top right corner
                if (cells_previous_state[i - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - ratio_width_height*dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                
                if (cells_previous_state[i - ratio_width_height*dimension*dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int top_right = -1; top_right < 1; top_right++)
                {
                    if (cells_previous_state[i - (ratio_width_height*dimension-1)*dimension + top_right].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
            }
            else if (i%dimension == 0)
            { //for bottom edge
                if (cells_previous_state[i - dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int top = 0; top < 3; top++)
                {
                    if (cells_previous_state[i + dimension*top - 1].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
                
            }
            else if (i%dimension == dimension-1)
            {//for top edge
                if (cells_previous_state[i - dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int bottom = 0; bottom < 3; bottom++)
                {
                    if (cells_previous_state[i - dimension*bottom + 1].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
            }
            else if (i < dimension)
            {//for left edge
                if (cells_previous_state[i - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int right = -1; right < 2; right++)
                {
                    if (cells_previous_state[i + (ratio_width_height*dimension-1)*dimension + right].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
            }
            else if (i > dimension*(ratio_width_height*dimension-1))
            {//for right edge
                if (cells_previous_state[i - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - dimension - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }

                for (int right = -1; right < 2; right++)
                {
                    if (cells_previous_state[i - (ratio_width_height*dimension-1)*dimension + right].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
            }
            else
            {
                // for cells_previous_state inside
                for (int j = -1; j < 2; j++)
                {
                    if (cells_previous_state[i - dimension + j].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                }
                for (int k=-1; k < 2; k++)
                {
                    
                    if (cells_previous_state[i + dimension + k].gameObject.tag == "Cell_Alive")
                    {
                        neighbourghs++;
                    }
                    
                }
                if (cells_previous_state[i + 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
                if (cells_previous_state[i - 1].gameObject.tag == "Cell_Alive")
                {
                    neighbourghs++;
                }
            }

            SpriteRenderer color_change = cells[i].GetComponent<SpriteRenderer>();
            if (cells_previous_state[i].gameObject.tag == "Cell_Alive" &&  neighbourghs != 3 && neighbourghs != 2)
            {
                cells[i].gameObject.tag = "Cell_Dead";
                color_change.color = Color.black;
            }
            else if (cells_previous_state[i].gameObject.tag == "Cell_Dead" &&  neighbourghs == 3 )
            {
                cells[i].gameObject.tag = "Cell_Alive";
                color_change.color = Color.white;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int x=0; x< ratio_width_height*dimension; x++ )
        {
            for (int y=0; y < dimension; y++)
            {
                GameObject temp = Instantiate(cell,new Vector3(x,y,0), Quaternion.identity, parent);
                cells.Add(temp);
                
                int alive_or_not = Random.Range(0,100);
                SpriteRenderer color_change = cells[dimension*x+y].GetComponent<SpriteRenderer>();
                if (alive_or_not % 8 == 0)
                {
                    cells[dimension*x+y].gameObject.tag = "Cell_Alive";
                    color_change.color = Color.white;
                }
                else 
                {
                    cells[dimension*x+y].gameObject.tag = "Cell_Dead";
                    color_change.color = Color.black;
                }
            }
        }

        cam.transform.position = new Vector3((ratio_width_height*dimension-1)/2 , (dimension-1)/2, -10);
        cam.orthographicSize = dimension*0.60f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Game_of_life();
            timer -= waitTime;
        }
    }
}
