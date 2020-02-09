using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Interact : MonoBehaviour
{
    public KeyCode Interact_Key;
    public GameObject[] raw;
    public GameObject[] spawn_box;
    public GameObject[] bake_box;
    public GameObject finished;
    public Transform hand;
    public Transform table_hold;
    public Transform[] bake_point;
    public ScoreSystem sc;
    public SpriteRenderer[] working;

    bool[] near_spawn_mat = { false, false, false };
    bool[] near_bake = { false, false, false };
    bool near_table = false;
    bool near_finished = false;


    string[] state = { "No", "Cement", "Silver", "Log", "Poon", "Metal", "Wood" };
    string current_state = null;

    void Start()
    {
        current_state = state[0];
        sc = FindObjectOfType<ScoreSystem>();
        working[0].enabled = false;
        working[1].enabled = false;
        working[2].enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(Interact_Key))
        {
            if (current_state == "No")
            {
                if (near_spawn_mat[0])
                {
                    SetMat(hand, raw[0]);
                    current_state = state[1];
                }
                else if (near_spawn_mat[1])
                {
                    SetMat(hand, raw[1]);
                    current_state = state[2];
                }
                else if (near_spawn_mat[2])
                {
                    SetMat(hand, raw[2]);
                    current_state = state[3];
                }

                if (near_table)
                {
                    if (table_hold.GetChild(0).gameObject.name == (raw[0].name + "(Clone)"))
                    {
                        Destroy(table_hold.GetChild(0).gameObject);
                        SetMat(hand, raw[0]);
                        current_state = state[1];
                    }
                    if (table_hold.GetChild(0).gameObject.name == (raw[1].name + "(Clone)"))
                    {
                        Destroy(table_hold.GetChild(0).gameObject);
                        SetMat(hand, raw[1]);
                        current_state = state[2];
                    }
                    if (table_hold.GetChild(0).gameObject.name == (raw[2].name + "(Clone)"))
                    {
                        Destroy(table_hold.GetChild(0).gameObject);
                        SetMat(hand, raw[2]);
                        current_state = state[3];
                    }
                    if (table_hold.GetChild(0).gameObject.name == (raw[3].name + "(Clone)"))
                    {
                        Destroy(table_hold.GetChild(0).gameObject);
                        SetMat(hand, raw[3]);
                        current_state = state[4];
                    }
                    if (table_hold.GetChild(0).gameObject.name == (raw[4].name + "(Clone)"))
                    {
                        Destroy(table_hold.GetChild(0).gameObject);
                        SetMat(hand, raw[4]);
                        current_state = state[5];
                    }
                    if (table_hold.GetChild(0).gameObject.name == (raw[5].name + "(Clone)"))
                    {
                        Destroy(table_hold.GetChild(0).gameObject);
                        SetMat(hand, raw[5]);
                        current_state = state[6];
                    }
                }
                if (near_bake[0] && bake_point[0].GetChild(0).gameObject.name == (raw[3].name + "(Clone)"))
                {
                    Destroy(bake_point[0].GetChild(0).gameObject);
                    SetMat(hand, raw[3]);
                    current_state = state[4];
                }
                if (near_bake[1] && bake_point[1].GetChild(0).gameObject.name == (raw[4].name + "(Clone)"))
                {
                    Destroy(bake_point[1].GetChild(0).gameObject);
                    SetMat(hand, raw[4]);
                    current_state = state[5];
                }
                if (near_bake[2] && bake_point[2].GetChild(0).gameObject.name == (raw[5].name + "(Clone)"))
                {
                    Destroy(bake_point[2].GetChild(0).gameObject);
                    SetMat(hand, raw[5]);
                    current_state = state[6];
                }
            }
            else if (current_state != "No")
            {
                if (near_table)
                {
                    if (current_state == state[1] && table_hold.childCount == 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        SetMat(table_hold, raw[0]);
                        current_state = state[0];
                    }
                    else if (current_state == state[2] && table_hold.childCount == 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        SetMat(table_hold, raw[1]);
                        current_state = state[0];
                    }
                    else if (current_state == state[3] && table_hold.childCount == 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        SetMat(table_hold, raw[2]);
                        current_state = state[0];
                    }
                    else if (current_state == state[4] && table_hold.childCount == 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        SetMat(table_hold, raw[3]);
                        current_state = state[0];
                    }
                    else if (current_state == state[5] && table_hold.childCount == 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        SetMat(table_hold, raw[4]);
                        current_state = state[0];
                    }
                    else if (current_state == state[6] && table_hold.childCount == 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        SetMat(table_hold, raw[5]);
                        current_state = state[0];
                    }
                }
                if (near_bake[0] && current_state == state[1] && bake_point[0].childCount == 0)
                {
                    Destroy(hand.GetChild(0).gameObject);
                    SetMat(bake_point[0], raw[0]);
                    current_state = state[0];
                    StartCoroutine(BakeTime(5.0f, bake_point[0], raw[3], 0));
                }
                if (near_bake[1] && current_state == state[2] && bake_point[1].childCount == 0)
                {
                    Destroy(hand.GetChild(0).gameObject);
                    SetMat(bake_point[1], raw[1]);
                    current_state = state[0];
                    StartCoroutine(BakeTime(8.0f, bake_point[1], raw[4], 1));
                }
                if (near_bake[2] && current_state == state[3] && bake_point[2].childCount == 0)
                {
                    Destroy(hand.GetChild(0).gameObject);
                    SetMat(bake_point[2], raw[2]);
                    current_state = state[0];
                    StartCoroutine(BakeTime(3.0f, bake_point[2], raw[5], 2));
                }
                if (near_finished)
                {
                    if (current_state == state[4])
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        sc.SetScore("Poon");
                        current_state = state[0];
                    }
                    if (current_state == state[5])
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        sc.SetScore("Metal");
                        current_state = state[0];
                    }
                    if (current_state == state[6])
                    {
                        Destroy(hand.GetChild(0).gameObject);
                        sc.SetScore("Wood");
                        current_state = state[0];
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == spawn_box[0])
        {
            near_spawn_mat[0] = true;
        }
        if (other.gameObject == spawn_box[1])
        {
            near_spawn_mat[1] = true;
        }
        if (other.gameObject == spawn_box[2])
        {
            near_spawn_mat[2] = true;
        }
        if (other.gameObject == bake_box[0])
        {
            near_bake[0] = true;
        }
        if (other.gameObject == bake_box[1])
        {
            near_bake[1] = true;
        }
        if (other.gameObject == bake_box[2])
        {
            near_bake[2] = true;
        }
        if (other.gameObject == finished)
        {
            near_finished = true;
        }

        if (other.gameObject.CompareTag("Table"))
        {
            near_table = true;
            table_hold = other.transform.GetChild(0);
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == spawn_box[0])
        {
            near_spawn_mat[0] = false;
        }
        if (other.gameObject == spawn_box[1])
        {
            near_spawn_mat[1] = false;
        }
        if (other.gameObject == spawn_box[2])
        {
            near_spawn_mat[2] = false;
        }
        if (other.gameObject == bake_box[0])
        {
            near_bake[0] = false;
        }
        if (other.gameObject == bake_box[1])
        {
            near_bake[1] = false;
        }
        if (other.gameObject == bake_box[2])
        {
            near_bake[2] = false;
        }
        if (other.gameObject == finished)
        {
            near_finished = false;
        }

        if (other.gameObject.CompareTag("Table"))
        {
            near_table = false;
        }
    }

    void SetMat(Transform location, GameObject mat)
    {
        Instantiate(mat, location.position, location.rotation).transform.SetParent(location);
    }
    IEnumerator BakeTime(float delay, Transform location, GameObject mat, int index)
    {
        working[index].enabled = true;
        yield return new WaitForSeconds(delay);
        Destroy(location.GetChild(0).gameObject);
        SetMat(location, mat);
        working[index].enabled = false;
    }
}
