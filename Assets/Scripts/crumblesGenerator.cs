using UnityEngine;

public class crumblesGenerator : MonoBehaviour {

    public GameObject Crumble;
    public GameObject Stone;
    public static int numberOfCrumbles = 100;
    public static int numberOfStones = (int)(numberOfCrumbles / 10);
    private GameObject Ground;
    private Vector3[] CrumblesCoordinates = new Vector3[numberOfCrumbles];
    private Vector3[] StonesCoordinates = new Vector3[numberOfStones];
    private float x_min;
    private float x_max;
    private float z_min;
    private float z_max;
    private float f_x;
    private float f_z;
    private float margin=5;
    // Use this for initialization
    void Start () {
        //Debug.Log("x_max " + x_max + " x_min " + x_min);
        setArea();
        FountainSizes();
        PlaceObjects();
    }
    void PlaceObjects()
    {
        int all_size = numberOfCrumbles + numberOfStones;
        int j = 0;
        bool new_value;
        Vector3[] AllCoordinates = new Vector3[all_size];

        
        for (int i = 0; i < all_size; i++)
        {
            AllCoordinates[i] = GeneratedPosition();
            new_value = CheckValues(AllCoordinates, i);
            while ((AllCoordinates[i].x > -f_x - margin && AllCoordinates[i].x < f_x + margin && AllCoordinates[i].z > -f_z - margin && AllCoordinates[i].z < f_z + margin) || !new_value)
            {
                AllCoordinates[i] = GeneratedPosition();
                new_value = CheckValues(AllCoordinates, i);
            }
            if (i < numberOfCrumbles)
            {
                CrumblesCoordinates[i] = AllCoordinates[i];
                Instantiate(Crumble, CrumblesCoordinates[i], Quaternion.identity);
            }
            else {
                StonesCoordinates[j] = AllCoordinates[i];
                Instantiate(Stone, StonesCoordinates[j], Quaternion.identity);
                j++;
            }
           
        }
    }
    bool CheckValues(Vector3[] Coord, int i) {
        for (int j = 0; j < i; j++)
        {
            if (Coord[j]== Coord[i])
            {
                return false;
            }
        }
        return true;
    }
    void FountainSizes()
    {
        float fx_size = GameObject.Find("Fountain").GetComponent<Renderer>().bounds.size.x;
        float fz_size = GameObject.Find("Fountain").GetComponent<Renderer>().bounds.size.z;
        f_x = fx_size / 2;
        f_z = fz_size / 2;
    }
    void setArea()
    {       
        Ground = GameObject.Find("Pavement");
        float x_size = Ground.GetComponent<Renderer>().bounds.size.x;
        float z_size = Ground.GetComponent<Renderer>().bounds.size.z;
        x_max = x_size/2 - 0.1f * x_size;
        x_min = - x_max;
        z_max = z_size/2 - 0.1f * z_size;
        z_min = -z_max;
        //Debug.Log("x_max " + x_max + " x_min " + x_min);
        //Debug.Log("z_max " + z_max + " z_min " + z_min);
    }
    Vector3 GeneratedPosition()
    {
        float x,y,z;  
        x = Random.Range(x_min, x_max);
        y = Crumble.transform.position.y; //get y from Crumble prefabs
        z = Random.Range(z_min, z_max);
        return new Vector3(x, y, z);
    }
}
