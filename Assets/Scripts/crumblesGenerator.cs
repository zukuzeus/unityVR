using UnityEngine;

public class crumblesGenerator : MonoBehaviour
{

    public GameObject Crumble;
    public GameObject Stone;
    public GameObject Pigeon;
    private GameObject Ground;
    private Vector3[] CrumblesCoordinates = new Vector3[numberOfCrumbles];
    private Vector3[] StonesCoordinates = new Vector3[numberOfStones];
    public static int numberOfCrumbles = 100;
    public static int numberOfStones = (int)(numberOfCrumbles / 10);
    private float[] AreaBounds = new float[4];
    private float fountain_x_half_size;
    private float fountain_z_half_size;
    private float crumble_x_half_size;
    private float crumble_z_half_size;
    private float marginFromFountain = 2.0f;
    private float marginFromCrumble = 0.5f;
    // Use this for initialization
    void Start()
    {

        Debug.Log(Crumble.GetComponent<Renderer>().bounds.size.x);
        Debug.Log(Crumble.GetComponent<Renderer>().bounds.size.z);
        PlaceObjectsOnArea();
        Instantiate(Pigeon, Pigeon.transform.position, Quaternion.identity);
    }
    void PlaceObjectsOnArea()
    {
        SetAreaForPlacingObjects();
        CalculateCrumbleSize();
        CalculateFountainSize();
        int all_size = numberOfCrumbles + numberOfStones;
        int j = 0;
        Vector3[] AllCoordinates = new Vector3[all_size];

        for (int i = 0; i < all_size; i++)
        {
            AllCoordinates[i] = GetPositionForObject();
            while (CheckIfCoordinatesAreInsideFountain(AllCoordinates, i) || !CheckIfObjectCoordinatesAreNew(AllCoordinates, i))
            {
                AllCoordinates[i] = GetPositionForObject();
            }
            if (i < numberOfCrumbles)
            {
                CrumblesCoordinates[i] = AllCoordinates[i];
                Instantiate(Crumble, CrumblesCoordinates[i], Quaternion.identity);
            }
            else
            {
                StonesCoordinates[j] = AllCoordinates[i];
                Instantiate(Stone, StonesCoordinates[j], Quaternion.identity);
                j++;
            }

        }
    }
    bool CheckIfCoordinatesAreInsideFountain(Vector3[] AllCoordinates, int i)
    {
        return (AllCoordinates[i].x > -fountain_x_half_size - marginFromFountain && AllCoordinates[i].x < fountain_x_half_size + marginFromFountain && AllCoordinates[i].z > -fountain_z_half_size - marginFromFountain && AllCoordinates[i].z < fountain_z_half_size + marginFromFountain);
    }

    bool CheckIfObjectCoordinatesAreNew(Vector3[] Coordinates, int i)
    {
        for (int j = 0; j < i; j++)
        {
            if (Coordinates[i].x > Coordinates[j].x - crumble_x_half_size - marginFromCrumble && Coordinates[i].x < Coordinates[j].x + crumble_x_half_size + marginFromCrumble && Coordinates[i].z > Coordinates[j].z - crumble_z_half_size - marginFromCrumble && Coordinates[i].z < Coordinates[j].z + crumble_z_half_size + marginFromCrumble)
            {
                return false;
            }
        }
        return true;
    }
    void CalculateCrumbleSize()
    {
        crumble_x_half_size = Crumble.GetComponent<Renderer>().bounds.size.x / 2;
        crumble_z_half_size = Crumble.GetComponent<Renderer>().bounds.size.z / 2;
    }
    void CalculateFountainSize()
    {
        float fountain_x_size = GameObject.Find("Fountain").GetComponent<Renderer>().bounds.size.x;
        float funtain_z_size = GameObject.Find("Fountain").GetComponent<Renderer>().bounds.size.z;
        fountain_x_half_size = fountain_x_size / 2;
        fountain_z_half_size = funtain_z_size / 2;
    }
    void SetAreaForPlacingObjects()
    {
        Ground = GameObject.Find("Pavement");
        float area_x_size = Ground.GetComponent<Renderer>().bounds.size.x;
        float area_z_size = Ground.GetComponent<Renderer>().bounds.size.z;
        AreaBounds[0] = area_x_size / 2 - 0.1f * area_x_size; // x_max
        AreaBounds[1] = -AreaBounds[0];//x_min
        AreaBounds[2] = area_z_size / 2 - 0.1f * area_z_size;//z_max
        AreaBounds[3] = -AreaBounds[2];//z_min
    }
    Vector3 GetPositionForObject()
    {
        float x, y, z;
        x = Random.Range(AreaBounds[1], AreaBounds[0]);
        y = Crumble.transform.position.y; //get y from Crumble prefabs
        z = Random.Range(AreaBounds[3], AreaBounds[2]);
        return new Vector3(x, y, z);
    }
}
