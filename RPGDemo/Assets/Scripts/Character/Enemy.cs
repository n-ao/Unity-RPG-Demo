using System.Collections;
using UnityEngine;

namespace nao.myproject.rpg.battle
{
    /// <summary>
    /// 敵クラス
    /// </summary>
    class Enemy : MonoBehaviour, IEnemy
    {
        #region private fields
        [SerializeField] private GameObject _enemyGameObject;
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _hp;
        [SerializeField] private int _mp;
        [SerializeField] private int _atk;
        [SerializeField] private int _def;
        #endregion

        #region public accesors
        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level; set => _level = value; }
        public int Hp { get => _hp; set => _hp = value; }
        public int Mp { get => _mp; set => _mp = value; }
        public int Atk { get => _atk; set => _atk = value; }
        public int Def { get => _def; set => _def = value; }
        public bool IsDead
        {
            get
            {
                if (Hp <= 0)
                {
                    StartCoroutine(Dead()); // 敵死亡
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Unity methods
        private void Start()
        {
            StartCoroutine(ScaleEnemy(count: 50, rate: 0.0003f, shouldScaleUp: true, duration: 1.0f));
        }

        /// <summary>
        /// 敵を拡大縮小する
        /// </summary>
        /// <param name="count"></param>
        /// <param name="rate"></param>
        /// <param name="shouldScaleUp"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        IEnumerator ScaleEnemy(int count, float rate, bool shouldScaleUp, float duration)
        {
            for (int i = 0; i < count; i++)
            {
                float scaleValue;
                if (shouldScaleUp)
                {
                    scaleValue = i * rate;
                }
                else
                {
                    scaleValue = i * -rate;
                }
                _enemyGameObject.transform.localScale = new Vector3(
                    _enemyGameObject.transform.localScale.x + scaleValue
                    , _enemyGameObject.transform.localScale.y + scaleValue * 2
                    , _enemyGameObject.transform.localScale.z + scaleValue);
                yield return new WaitForSeconds(duration / count);
            }

            yield return new WaitForSeconds(0.1f);
            if (!IsDead)
            {
                StartCoroutine(ScaleEnemy(count, rate, !shouldScaleUp, duration));
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// 敵が死んだときの処理
        /// </summary>
        IEnumerator Dead()
        {
            yield return new WaitForSeconds(0.1f);
            _enemyGameObject.SetActive(false);
        }
        #endregion

        #region public methods
        /// <summary>
        /// 敵の情報を表示します。
        /// </summary>
        public string ShowInfo()
        {
            string retMessage = BuildMessage(MessageType.ShowInfo);
            return retMessage;
        }

        /// <summary>
        /// 相手を攻撃します。
        /// </summary>
        /// <param name="someOne"></param>
        public string Attack(IHuman someOne)
        {
            string retMessage = BuildMessage(MessageType.Attack, attackTarget: someOne);
            // ダメージを与える
            someOne.Hp -= Atk;
            return retMessage;
        }
        #endregion

        #region Message
        /// <summary>
        /// メッセージのタイプ
        /// </summary>
        private enum MessageType
        {
            ShowInfo,
            Attack,
        }

        /// <summary>
        /// メッセージテンプレートを組み立てます。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attackTarget">オプション：攻撃の場合の相手</param>
        /// <returns></returns>
        private string BuildMessage(MessageType type, IHuman attackTarget = null)
        {
            string ret = "";

            switch (type)
            {
                case MessageType.ShowInfo:
                    ret = Name + "の情報を表示します。" + "\n レベル：" + Level + "\n HP：" + Hp + "\n MP：" + Mp + "\n 攻撃力：" + Atk + "\n 防御力：" + Def;
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
    }
}