using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Client : MonoBehaviour
{
    public GameObject Chicken;
    public GameObject Cat;
    public GameObject Fish;
    public GameObject Duck;
    public GameObject Shark;
    public GameObject Snake;

    public bool IhasLeg;
    public bool ICanSwim;
    public bool IEdible;

    public List<GameObject> list = new List<GameObject>();

    public Toggle Leg;
    public Toggle Swim;
    public Toggle Edi;
    public Text text1;
    public void OnPress()
    {
        AnimalRequirement requirements = new AnimalRequirement();
        requirements.hasLeg = Leg.isOn;
        requirements.CanSwim = Swim.isOn;
        requirements.Edible = Edi.isOn;
        IAnimal k = GetAnimal(requirements);
        text1.text = k.ToString();

        GameObject spawnObject = (GameObject)Instantiate(Resources.Load(k.ToString()));
        list.Add(spawnObject);
        Debug.Log(k);
    }

    public void OnPressClear()
    {
        foreach(GameObject x in list){
            Destroy(x.gameObject);
        }
        list.Clear();
    }

    // Start is called before the first frame update

    // Update is called once per frame

    private static IAnimal GetAnimal(AnimalRequirement requirements)
    {
        AnimalFactory factory = new AnimalFactory(requirements);
        return factory.Create();
    }
}
