using UnityEngine;

public class Background_loop : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = -5f;
    [SerializeField] private Vector2 startPos;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;

        // init scrool speed
        GameManager.Instance.SetScroolSpeed(-scrollSpeed);
    }

    // Update is called once per frame
    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 10);
        transform.position = startPos + Vector2.up * newPos;
    }

    public void SetSpeed(float scrollSpeed)
    {
        this.scrollSpeed = scrollSpeed;
    }
}
