using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    public Vector2[] states;
    public Data db;
    public float timer = 1f;
    public int osc = 1;
    void Update()
    {
        timer += Time.deltaTime;
        GetComponent<RectTransform>().anchoredPosition = states[db.Progress];
        GetComponent<RectTransform>().localScale += osc * Time.deltaTime / 18 * (new Vector3(1, 1, 0));
        if (transform.localScale.x > 0.11f)
        {
            osc = -1;
        } else if (transform.localScale.x < 0.09f)
        {
            osc = 1;
        }
    }
}
