using UnityEngine;
using UnityEngine.UI;

namespace nao.myproject.rpg.battle
{
    #region Player
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    class Player : MonoBehaviour, IPlayer
    {
        #region private fields
        [SerializeField] private Sprite _playerImage;
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _hp;
        [SerializeField] private int _mp;
        [SerializeField] private int _atk;
        [SerializeField] private int _def;
        #endregion

        #region public accesors
        public Sprite PlayerImage { get => _playerImage; set => _playerImage = value; }
        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level; set => _level = value; }
        public int Hp { get => _hp; set => _hp = value; }
        public int Mp { get => _mp; set => _mp = value; }
        public int Atk { get => _atk; set => _atk = value; }
        public int Def { get => _def; set => _def = value; }
        #endregion

        #region public methods
        /// <summary>
        /// プレイヤーが話します。
        /// </summary>
        /// <param name="message"></param>
        public string Say(string message)
        {
            string retMessage = BuildMessage(MessageType.Say, sayMessage: message);
            return retMessage;
        }

        /// <summary>
        /// プレイヤーの情報を表示します。
        /// </summary>
        public string ShowInfo()
        {
            string retMessage = BuildMessage(MessageType.ShowInfo);
            return retMessage;
        }

        /// <summary>
        /// プレイヤーが攻撃します。
        /// </summary>
        /// <param name="someOne"></param>
        public string Attack(IHuman someOne)
        {
            string retMessage = BuildMessage(MessageType.Attack, attackTarget: someOne);
            // ダメージを与える
            someOne.Hp -= Atk;
            return retMessage;
        }

        /// <summary>
        /// プレイヤーのレベルを上げます。
        /// </summary>
        public void LevelUp()
        {
            Level++;
            Atk += 10;
            Def += 10;
        }
        #endregion

        #region Message
        /// <summary>
        /// メッセージのタイプ
        /// </summary>
        private enum MessageType
        {
            ShowInfo,
            Say,
            Attack,
        }

        /// <summary>
        /// メッセージテンプレートを組み立てます。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sayMessage">オプション：sayの場合のメッセージ</param>
        /// <param name="attackTarget">オプション：攻撃の場合の相手</param>
        /// <returns></returns>
        private string BuildMessage(MessageType type, string sayMessage = "", IHuman attackTarget = null)
        {
            string ret = "";

            switch (type)
            {
                case MessageType.ShowInfo:
                    ret = "名前：" + Name + "\n レベル：" + Level + "\n HP：" + Hp + "\n MP：" + Mp + "\n 攻撃力：" + Atk + "\n 防御力：" + Def;
                    break;
                case MessageType.Say:
                    ret = Name + "が" + sayMessage + "と言っています。";
                    break;
                case MessageType.Attack:
                    ret = ("\n" + Name + "が" + attackTarget.Name + "を攻撃します。\n")
                        + (Atk + "のダメージ。（" + attackTarget.Name + "のHP:" + attackTarget.Hp + "=> " + (attackTarget.Hp - Atk).ToString() + ")\n");
                    break;
                default:
                    break;
            }
            return ret;
        }
        #endregion

        #region Explicit interface methods
        // 以下未実装
        void IPlayer.Move()
        {
            Debug.Log(Name + "が移動しました");
        }
        void IPlayer.Talk() { }
        void IWalkable.Walk() { }
        #endregion
    }
    #endregion
}