using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OtherSpritesScaleClass
{
    [Tooltip("Transforms that have the same scale ratio can be added here.")]
    public Transform[] sprites;
    [Tooltip("Set the scale ratio compared to the Reference Sprite.")]
    public float scaleRatioToReferenceSprite = 1;
}
public class RescaleScript : MonoBehaviour
{
    [Tooltip("This is the object in the world that will be rescaled to fill the screens width. All pther game objects that are added will be set to the same scale")]
    public Transform referenceObject;
    [Tooltip("These are the game objects that will be set to the same scale as the Reference Object.")]
    public OtherSpritesScaleClass[] otherSprites;
    [Tooltip("UI elements to move to the top of the Reference Object")]
    public RectTransform player1Stats, player2Stats;
    [Tooltip("The canvas (or parent) of the player1Stats and player2Stats")]
    public RectTransform canvasRect;

    public GameObject testingPrefab;
    private GameObject boundsCenter, boundsCenterPlusExtends;
    private int screenWidthLastFrame, screenHeightLastFrame;
    private SpriteRenderer referenceSprite;
    void Start()
    {
        referenceSprite = referenceObject.GetComponent<SpriteRenderer>();
        screenWidthLastFrame = Screen.width;
        screenHeightLastFrame = Screen.height;
        ScaleAll();
    }
    private void Update()
    {
        int screenWidthThisFrame = Screen.width, screenHeightThisFrame = Screen.height; //Camera.main.pixelWidth
        if (screenWidthThisFrame != screenWidthLastFrame || screenHeightThisFrame != screenHeightLastFrame)
        {
            screenWidthLastFrame = screenWidthThisFrame;
            screenHeightLastFrame = screenHeightThisFrame;
            ScaleAll();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) Debug.Log($"Mouse position is: {Input.mousePosition}");
    }
    void ScaleAll()
    {
        float width = GetScreenToWorldWidth;
        referenceObject.localScale = Vector3.one * width;
        for (int i = 0; i < otherSprites.Length; i++)
        {
            for (int j = 0; j < otherSprites[i].sprites.Length; j++)
            {
                otherSprites[i].sprites[j].localScale = Vector3.one * width * otherSprites[i].scaleRatioToReferenceSprite;
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
