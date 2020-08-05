using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages a collection of flower plants
/// </summary>
public class FlowerArea : MonoBehaviour
{
    // The diameter of the area where the agent and flowers can be
    // used for observing relative distance from agent to flower
    public const float AreaDiameter = 20f;

    // The list of all flower plants in this flower area (flower plants have multiple flowers)
    private List<GameObject> flowerPlants;

    // A lookup dictionary for looking up a flower from a nectar collider
    private Dictionary<Collider, Flower> nectarFlowerDictionary;

    /// <summary>
    /// The list of all flowers in the flower area
    /// </summary>
    public List<Flower> Flowers { get; private set; }

    /// <summary>
    /// Reset the flowers and flower plants
    /// </summary>
    public void ResetFlowers()
    {
        // Rotate each flower plant around the Y axis and subtly around X and Z (so we need to loop through from all the flower plant)
        foreach (GameObject flowerPlant in flowerPlants)
        { 
            //(we want to generate three random variable for this we use unityengine. random )
            float xRotation = UnityEngine.Random.Range(-5f, 5f);
            float yRotation = UnityEngine.Random.Range(-180f, 180f);
            float zRotation = UnityEngine.Random.Range(-5f, 5f);
            flowerPlant.transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        }

        // Reset each flower
        foreach (Flower flower in Flowers)
        {
            flower.ResetFlower();
        }
    }

    /// <summary>
    /// Gets the <see cref="Flower"/> that a nectar collider belongs to (the idea for this function is to check which flowe belong to which nectar collider)
    /// </summary>
    /// <param name="collider">The nectar collider</param>
    /// <returns>The matching flower</returns>
    public Flower GetFlowerFromNectar(Collider collider)
    {
        return nectarFlowerDictionary[collider];
    }

    /// <summary>
    /// Called when the area wakes up
    /// </summary>
    private void Awake()
    {
        // Initialize variables
        flowerPlants = new List<GameObject>();
        nectarFlowerDictionary = new Dictionary<Collider, Flower>();
        Flowers = new List<Flower>();

        // Find all flowers that are children of this GameObject/Transform/(flower area)
        FindChildFlowers(transform);
    }

    /// <summary>
    /// Recursively finds all flowers and flower plants that are children of a parent transform (we use recursion here function call itself to reach a base case(sinfle flower))
    /// </summary>
    /// <param name="parent">The parent of the children to check</param>
    private void FindChildFlowers(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            //(this is a fuction to get parent child)
            Transform child = parent.GetChild(i);

            //(At this calling some transform from the scenes)
            if (child.CompareTag("flower_plant"))
            {
                // Found a flower plant, add it to the flowerPlants list
                flowerPlants.Add(child.gameObject);

                // Look for flowers within the flower plant
                FindChildFlowers(child);
            }
            else
            {
                // Not a flower plant, look for a Flower component
                Flower flower = child.GetComponent<Flower>();
                if (flower != null)
                {
                    // Found a flower, add it to the Flowers list
                    Flowers.Add(flower);

                    // Add the nectar collider to the lookup dictionary
                    nectarFlowerDictionary.Add(flower.nectarCollider, flower);

                    // Note: there are no flowers that are children of other flowers
                }
                else
                {
                    // Flower component not found, so check children
                    FindChildFlowers(child);
                }
            }
        }
    }

}
