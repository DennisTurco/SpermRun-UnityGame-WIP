using System.Collections;
using UnityEngine;

public class Background_loop : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 3f;
    [SerializeField] private float incrementSpeed = 0.8f;
    [SerializeField] private float timeBeforeIncrementSpeed = 10f;
    [SerializeField] private Vector2 startPos;

    // Start is called before the first frame update
    private void Start()
    {
        scrollSpeed = -scrollSpeed;
        incrementSpeed = -incrementSpeed;

        startPos = transform.position;

        // init scrool speed
        GameManager.Instance.SetScroolSpeed(-scrollSpeed);

        StartCoroutine("IncrementSpeed");
    }

    // Update is called once per frame
    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 10);
        transform.position = startPos + Vector2.up * newPos;
    }

    private IEnumerator IncrementSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBeforeIncrementSpeed);
            SetSpeed(scrollSpeed + incrementSpeed);
            GameManager.Instance.SetScroolSpeed(-scrollSpeed);
        }
    }

    public void SetSpeed(float scrollSpeed)
    {
        this.scrollSpeed = scrollSpeed;
    }
}
