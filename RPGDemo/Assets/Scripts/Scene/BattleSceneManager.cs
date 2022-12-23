using UnityEngine;

namespace nao.myproject.rpg.battle
{
    /// <summary>
    /// バトルシーン管理クラス
    /// </summary>
    [RequireComponent(typeof(BattleTurn), typeof(Player), typeof(Enemy))]
    public class BattleSceneManager : MonoBehaviour
    {
        #region private fields
        private Player somePlayer;
        private Enemy someEnemy;
        private BattleTurn battle;
        [SerializeField] private BattleUI UI;
        [SerializeField] private EventManager eventManager;
        #endregion

        #region Unity methods
        private void Awake()
        {
            // 各コンポーネントの取得
            somePlayer = gameObject.GetComponent<Player>();
            someEnemy = gameObject.GetComponent<Enemy>();
            battle = GetComponent<BattleTurn>();

            UI = GetComponent<BattleUI>();

            // UI：プレイヤー情報の表示
            UI.PlayerImage = somePlayer.PlayerImage;
            UI.PlayerInfoText = somePlayer.ShowInfo();

            // UI: 攻撃ボタンの紐付け
            UI.AttackButton.onClick.AddListener(AttackOnce);
        }
        #endregion

        /// <summary>
        /// プレイヤーの攻撃を1回行う
        /// </summary>
        private void AttackOnce()
        {
            // プレイヤーの攻撃＆UI更新
            UI.LogInfoText = battle.Turn(somePlayer, someEnemy);
            eventManager.UpdateLogInfo.Invoke();
            UI.PlayerInfoText = somePlayer.ShowInfo();
        }
    }
}