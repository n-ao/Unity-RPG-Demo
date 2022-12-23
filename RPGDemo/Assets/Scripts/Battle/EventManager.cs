using UnityEngine;
using UnityEngine.Events;

namespace nao.myproject.rpg.battle
{
    /// <summary>
    /// イベント管理クラス
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        /// <summary>
        /// イベントタイプ
        /// </summary>
        public enum EventType
        {
            LOG_UDATE,  // ログ更新
            PLAYERINFO_UPDATE, // プレイヤー情報更新
            BATTLE_END, // バトル終了
        }

        #region public events
        /// <summary>
        /// ログ更新イベント
        /// </summary>
        public UnityEvent UpdateLogInfo;

        /// <summary>
        /// プレイヤー情報更新イベント
        /// </summary>
        public UnityEvent UpdatePlayerInfo;

        /// <summary>
        /// バトル終了イベント
        /// </summary>
        public UnityEvent BattleEnd;
        #endregion

        #region private Unity methods
        private void Start()
        {
            UpdateLogInfo.AddListener(OnLogInfoUpdated);
            UpdatePlayerInfo.AddListener(OnPlayerInfoUpdated);
            BattleEnd.AddListener(OnBattleEnd);
        }

        /// <summary>
        /// ログ情報更新イベント
        /// </summary>
        private void OnLogInfoUpdated()
        {
            Debug.Log("UI更新：ログ");
        }
        /// <summary>
        /// プレイヤー情報更新イベント
        /// </summary>
        private void OnPlayerInfoUpdated()
        {
            Debug.Log("UI更新：プレイヤー情報");
        }

        private void OnBattleEnd()
        {
            Debug.Log("バトル終了！");
        }
        #endregion
    }
}