using UnityEngine;

public class Portal : MonoBehaviour
{
    private float i = 0.01f;

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(i, i, i);
    }

    private void Update()
    {

        if (i <= 1f)
            i += 0.005f;

        gameObject.transform.localScale = new Vector3(i, i, i);

        
    }
}
