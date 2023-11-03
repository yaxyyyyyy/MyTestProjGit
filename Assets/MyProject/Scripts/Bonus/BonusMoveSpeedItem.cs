using UnityEngine;

public class BonusMoveSpeedItem : BonusItem
{
    [SerializeField] private float _newSpeed;
    [SerializeField] private float _timeBonus;

    private void OnCollisionEnter(Collision collision)
    {
        this.EntryToPool();
        GetBonus(collision.gameObject);
    }
    public override void GetBonus(GameObject targetBonus)
    {
        var move = targetBonus.GetComponent<IMove>();
        if (move != null)
        {
            var bonusSpeedOnPlayer = gameObject.GetComponent<BonusSpeedOnPlayer>();
            if (bonusSpeedOnPlayer != null)
            {
                bonusSpeedOnPlayer.CreateBonusOnPlayer(move, _newSpeed, _timeBonus);
            }
            else
            {
                bonusSpeedOnPlayer = gameObject.AddComponent<BonusSpeedOnPlayer>();
                bonusSpeedOnPlayer.CreateBonusOnPlayer(move, _newSpeed, _timeBonus);
            }

        }
    }
}
