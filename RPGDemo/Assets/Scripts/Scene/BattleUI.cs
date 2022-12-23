using UnityEngine;
using UnityEngine.UI;

namespace nao.myproject.rpg.battle
{
    /// <summary>
    /// バトル画面のUIクラス
    /// </summary>
    class BattleUI : MonoBehaviour
    {
        #region private fields
        [SerializeField] private Text _logInfoText;
        [SerializeField] private Text _playerInfoText;
        [SerializeField] private Image _playerImage;

        [SerializeField] private Button _attackButton;
        #endregion

        #region public accesors
        /// <summary>
        /// 情報表示するテキスト
        /// </summary>
        public string LogInfoText { get => _logInfoText.text; set => _logInfoText.text = value; }
        /// <summary>
        /// プレイヤーの情報を表示するテキスト
        /// </summary>
        public string PlayerInfoText { get => _playerInfoText.text; set => _playerInfoText.text = value; }
        /// <summary>
        /// プレイヤーの画像
        /// </summary>
        public Sprite PlayerImage { get => _playerImage.sprite; set => _playerImage.sprite = value; }

        /// <summary>
        /// 攻撃ボタン
        /// </summary>
        public Button AttackButton { get => _attackButton; }
        #endregion

        #region Unity methods
        private void Awake()
        {
            LogInfoText = "";
        }
        #endregion
    }
}