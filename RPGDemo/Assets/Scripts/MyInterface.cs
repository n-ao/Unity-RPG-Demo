
namespace nao.myproject.rpg.battle
{
    #region 要素
    #region プレイヤー
    /// <summary>
    /// プレイヤーのインターフェース
    /// </summary>
    public interface IPlayer : IHuman, ISpeakable, IWalkable
    {
        // プレイヤーは以下が可能。
        void Move();    // 移動
        void Talk();    // 会話

        // 喋れることができる
        // 歩くことができる
    }
    #endregion

    #region 敵
    /// <summary>
    /// 敵のインターフェースß
    /// </summary>
    public interface IEnemy : IHuman
    {
    }
    #endregion   

    #region 人間
    /// <summary>
    /// 人間のインターフェース
    /// </summary>
    /// <remarks>
    /// できることを含めすぎると、継承先インターフェースで実装が細かくなるのでバランスに注意
    /// </remarks>
    public interface IHuman
    {
        // 人間は以下のプロパティを持つ。
        string Name { get; set; }
        int Level { get; set; }
        int Hp { get; set; }
        int Mp { get; set; }
        int Atk { get; set; }
        int Def { get; set; }

        // 人間は以下が可能
        string ShowInfo(); // 情報表示
        string Attack(IHuman someOne);  // 攻撃
    }

    /// <summary>
    /// しゃべることができるインターフェース
    /// </summary>
    public interface ISpeakable
    {
        string Say(string message);
    }

    /// <summary>
    /// 食べることができるインターフェース
    /// </summary>
    public interface IEatable
    {
        void Eat();
    }

    /// <summary>
    /// 飲むことができるインターフェース
    /// </summary>
    public interface IDrinkable
    {
        void Drink();
    }

    /// <summary>
    /// 歩くことができるインターフェース
    /// </summary>
    public interface IWalkable
    {
        void Walk();
    }

    /// <summary>
    /// 走ることができるインターフェース
    /// </summary>
    public interface IRunnable
    {
        void Run();
    }
    #endregion
    #endregion

    #region Feature
    #region Field
    /// <summary>
    /// フィールドに関するインターフェース 
    /// </summary>
    public interface IField
    {
    }
    #endregion

    #region Battle
    /// <summary>
    /// 戦闘に関するインターフェース 
    /// </summary>
    public interface IBattle
    {
    }
    #endregion

    #region Communication
    /// <summary>
    /// 会話によるコミュニケーションに関するインターフェース
    /// </summary>
    public interface ITalk : ICommunication
    {
        void Say();
    }

    /// <summary>
    /// なんらかの手段でコミュニケーションするインターフェース
    /// </summary>
    public interface ICommunication
    {
    }
    #endregion
    #endregion // Feature
}