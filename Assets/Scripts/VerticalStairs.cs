using UnityEngine;

public class VerticalStairs : MonoBehaviour
{
    public bool isUp;

    private PlatformerPlayer _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerPlayer>();
    }

    private void Update()
    {
        var keyDownPressed = 
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        
        if (keyDownPressed && _player.isGrounded)
        {
            transform.parent.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetComponent<Collider2D>().enabled = isUp;
            _player.SetupClimb(isUp);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.SetupClimb(false);
        }
    }
}
