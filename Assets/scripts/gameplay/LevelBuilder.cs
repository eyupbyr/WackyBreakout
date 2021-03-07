using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] GameObject prefabPaddle;

    [SerializeField] GameObject prefabStandardBlock;
    [SerializeField] GameObject prefabBonusBlock;
    [SerializeField] GameObject prefabPickupBlock;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabPaddle);

        // retrieve block size
        GameObject tempBlock = Instantiate<GameObject>(prefabStandardBlock);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x;
        float blockHeight = collider.size.y;
        Destroy(tempBlock);

        // calculate blocks per row and make sure left block position centers row
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int blocksPerRow = (int)(screenWidth / blockWidth);
        float totalBlockWidth = blocksPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - totalBlockWidth) / 2 +
            blockWidth / 2;

        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        // add rows of blocks
        Vector2 currentPosition = new Vector2(leftBlockOffset, topRowOffset);
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < blocksPerRow; column++)
            {
                PlaceBlock(currentPosition);
                currentPosition.x += blockWidth;
            }

            // move to next row
            currentPosition.x = leftBlockOffset;
            currentPosition.y += blockHeight;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Places a randomly selected block at the given position
    /// </summary>
    void PlaceBlock(Vector2 position)
    {

        float probability = Random.value;

        if (probability < ConfigurationUtils.FreezerBlockProbability + ConfigurationUtils.SpeedupBlockProbability)
        {
            GameObject pickupBlock = Instantiate(prefabPickupBlock, position, Quaternion.identity);
            PickupBlock pickupBlockScript = pickupBlock.GetComponent<PickupBlock>();

            //calculate another random number and place either freezer or speedup block by giving 50 percent probability each
            float probability2 = Random.value;
            if (probability2 <= 0.5f)
                pickupBlockScript.Effect = PickupEffect.Freezer;
            else
                pickupBlockScript.Effect = PickupEffect.Speedup;
        }

        else if (probability < ConfigurationUtils.FreezerBlockProbability + ConfigurationUtils.SpeedupBlockProbability 
            + ConfigurationUtils.BonusBlockProbability)
        {
            Instantiate(prefabBonusBlock, position, Quaternion.identity);
        }

        else
            Instantiate(prefabStandardBlock, position, Quaternion.identity);
    }
}
