using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescaleScript : MonoBehaviour
{
    [Tooltip("This is the object in the world that will be rescaled to fill the screens width. All pther game objects that are added will be set to the same scale")]
    public Transform referenceObject;
    [Tooltip("These are the player objects that will be scaled in proportion to the Reference Sprite.")]
    public List<Transform> playerSprites = new List<Transform>();
    [Tooltip("Set the scale ratio between the player objects compared to the Reference Sprite.")]
    public float scaleRatioToReferenceSprite = 1;
    [Tooltip("UI elements to move to the top of the Reference Object")]
    public RectTransform player1Stats, player2Stats;
    [Tooltip("The canvas (or parent) of the player1Stats and player2Stats")]
    public RectTransform canvasRect;
    [Tooltip("The min and max start size for a character with scale 1. Will be scaled.")]
    public Vector2 startSizeParticles = new Vector2(1.8f, 2f);

    private Vector2 screenSizeLastFrame;
    private SpriteRenderer referenceSprite;
    void Start()
    {
        referenceSprite = referenceObject.GetComponent<SpriteRenderer>();
        screenSizeLastFrame = new Vector2(Screen.width, Screen.height);
        ScaleAll();
    }
    private void Update()
    {
        Vector2 screenSizeThisFrame = new Vector2(Screen.width, Screen.height);
        if (screenSizeThisFrame != screenSizeLastFrame)
        {
            screenSizeLastFrame = screenSizeThisFrame;
            ScaleAll();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) Debug.Log($"Mouse position is: {Input.mousePosition}");
    }
    public void ScaleAll()
    {
        float width = GetScreenToWorldWidth;
        referenceObject.localScale = Vector3.one * width;
        for (int i = 0; i < playerSprites.Count; i++)
        {
            playerSprites[i].localScale = Vector3.one * width * scaleRatioToReferenceSprite;
            ParticleSystem[] insults = playerSprites[i].GetComponentsInChildren<ParticleSystem>();
            PlayerMovement PM = playerSprites[i].GetComponent<PlayerMovement>();
            PM.scaledSpeed = PM.runSpeed * referenceObject.localScale.x; 
            foreach (ParticleSystem p in insults)
            {
                var main = p.main;
                main.startSize = 0.04f * referenceObject.localScale.x; //new ParticleSystem.MinMaxCurve(startSizeParticles.x * playerSprites[i].localScale.x, startSizeParticles.y * playerSprites[i].localScale.x);
                main.startSpeed = .33f * referenceObject.localScale.x;
            }
        }

        SetAnchorStats(player1Stats, 1);
        SetAnchorStats(player2Stats, 2);
    }
    void SetAnchorStats(RectTransform UIRect ,int player)
    {
        Vector3 daPos = referenceSprite.bounds.center;
        if(player == 1) daPos.x -= referenceSprite.bounds.extents.x;
        else daPos.x += referenceSprite.bounds.extents.x;
        daPos.y += referenceSprite.bounds.extents.y;

        Vector3 newVectorPos = Camera.main.WorldToScreenPoint(daPos);
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, newVectorPos, null, out anchoredPosition);

        UIRect.anchoredPosition = anchoredPosition;
    }
    
    public float GetScreenToWorldHeight
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner); var height = edgeVector.y * 2;
            return height;
        }
    }
    public float GetScreenToWorldWidth
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner); var width = edgeVector.x * 2;
            return width;
        }
    }
}
