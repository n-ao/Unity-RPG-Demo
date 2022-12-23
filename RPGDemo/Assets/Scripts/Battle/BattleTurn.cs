using UnityEngine;

namespace nao.myproject.rpg.battle
{
    /// <summary>
    /// バトルのターンを管理するクラス
    /// </summary>
    class BattleTurn : MonoBehaviour
    {
        /// <summary>
        /// ターン数（1始まり）
        /// </summary>
        int turnNum = 1;

        /// <summary>
        /// 戦闘終了フラグ
        /// </summary>
        bool battleEnd = false;

        /// <summary>
        /// ターンを実行します、（情報表示と攻撃）
        /// </summary>
        /// <param name="human"></param>
        /// <param name="target"></param>
        public string Turn(IHuman human, IHuman target)
        {
            // バトル終了の場合
            if (battleEnd)
            {
                return "敵はもういない。";
            }

            // UI表示するメッセージ
            string retMessage = "\n ▼ターン" + turnNum + "：" + human.Name + "のターン\n" + human.Attack(target);

            // 相手がEnemyの時
            if (target.GetType() == typeof(Enemy))
            {
                // Enemy死亡時
                Enemy enemy = (Enemy)target;
                if (enemy.IsDead)
                {
                    // このタイミングでバトル終了
                    retMessage += "\n" + human.Name + "は" + enemy.Name + "を倒した！！";
                    battleEnd = true;

                    // このタイミングでプレイヤーのレベルをアップ
                    Player player = (Player)human;
                    player.LevelUp();
                    retMessage += "\n" + human.Name + "のレベルが１アップした。";

                    // 上記メッセージを返却する。
                    return retMessage;
                }
            }
            // ターンのカウントを増やす
            turnNum++;
            return retMessage;
        }
    }
}