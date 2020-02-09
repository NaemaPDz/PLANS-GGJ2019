using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int home_score;
    public int wood_score;
    public int poon_score;
    public int metal_score;
    public GameObject[] home;
    public Transform home_holder;

    public TextMeshProUGUI HomeText;
    public TextMeshProUGUI PoonText;
    public TextMeshProUGUI MetalText;
    public TextMeshProUGUI WoodText;

    int wood_goal;
    int poon_goal;
    int metal_goal;

    // Start is called before the first frame update
    void Start()
    {
        RandomGoal();
        home_score = 0;
        wood_score = 0;
        poon_score = 0;
        metal_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HomeText.text = home_score + "";
        PoonText.text = poon_score + " / " + poon_goal;
        MetalText.text = metal_score + " / " + metal_goal;
        WoodText.text = wood_score + " / " + wood_goal;

        if (wood_score >= wood_goal && poon_score >= poon_goal && metal_score >= metal_goal)
        {
            wood_score -= wood_goal;
            poon_score -= poon_goal;
            metal_score -= metal_goal;

            home_score++;
            print(home_score);
            HomeShow();
            RandomGoal();
        }
    }

    public void SetScore (string mat)
    {
        if (mat == "Poon")
        {
            poon_score++;
            print("Poon : " + poon_score);
        }
        else if (mat == "Metal")
        {
            metal_score++;
            print("Metal : " + metal_score);
        }
        else if (mat == "Wood")
        {
            wood_score++;
            print("Wood : " + wood_score);
        }
    }

    void RandomGoal()
    {
        wood_goal = (int)Random.Range(1, 4);
        poon_goal = (int)Random.Range(1, 3);
        metal_goal = (int)Random.Range(1, 2);
    }

    void HomeShow()
    {
        GameObject h = null;
        if (home_score % 3 == 0)
        {
            h = Instantiate(home[0], home_holder.position, home[0].transform.rotation);
        }
        else if (home_score % 3 == 1)
        {
            h = Instantiate(home[1], home_holder.position, home[1].transform.rotation);
        }
        else if (home_score % 3 == 2)
        {
            h = Instantiate(home[2], home_holder.position, home[2].transform.rotation);
        }
    }
}
