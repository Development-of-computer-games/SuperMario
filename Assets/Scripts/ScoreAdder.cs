using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    [SerializeField] int pointsToAdd;
    public AudioClip saw;    // Add your Audi Clip Here;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == triggeringTag)
        {
            Destroy(collision.gameObject);
            scoreField.AddNumber(pointsToAdd);
            GetComponent<AudioSource>().Play();
        }
    }

    public void SetScoreField(NumberField newTextField)
    {
        this.scoreField = newTextField;
    }
}
