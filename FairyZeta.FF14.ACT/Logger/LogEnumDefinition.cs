﻿namespace FairyZeta.FF14.ACT.Logger
{
    /// <summary> 【列挙定義】出力するログの種類を表します。
    /// <para>Action: 「ユーザー側の操作」による出力。（ボタン押下、テキスト入力など)</para>
    /// <para>System: 「コード内部の動作」による出力。（算出の終了、分岐の判定結果など）</para>
    /// </summary>
    public enum LogTypeEnum
    {
        Action, System
    }

    /// <summary> 出力するログの成功と失敗の成果を表します。
    /// <para>Success: 成功の成果。(ログインの成功、画面遷移の成功など)</para>
    /// <para>Failure: 失敗の成果。(保存の失敗、更新の失敗など)</para>
    /// <para>NonState: 成果として表現できない場合。</para>
    /// </summary>
    public enum LogResultEnum
    {
        Success, Failure, NonState
    }

    /// <summary> 【列挙定義】ログ情報のレベル。上に行くほど重要情報となります。
    /// <para> --------- 異常情報 ----------------------------------------------------------------------------------------------------- </para>
    /// <para> FATAL: 異常を表します。異常を予期していない状態で、プログラムは続行不可能。</para>
    /// <para> ERROR: 異常を表します。異常を予期していない状態で、プログラムは続行可能。</para>
    /// <para> WARNING: 警告を表します。異常を予期している状態で、リカバリー可能である。（ファイルが無いため作成した、など）</para>
    /// <para> --------- 正常情報 ----------------------------------------------------------------------------------------------------- </para>
    /// <para> NOTICE: 情報を表します。INFOの上位レベルで、用途は同じですが、こちらは「ユーザーに通知するべき情報」です。（保存に成功した、など）</para>
    /// <para> INFO: 情報を表します。基本レベルの情報で、開始や終了の記録、内部状態など、注目すべき事象を記録します。</para>
    /// <para> MEMO: 情報を表します。INFOの下位レベルで、処理速度やファイル容量を考えた場合に「記録しないこと」を視野に入れる情報です。</para>
    /// <para> --------- 開発情報 ----------------------------------------------------------------------------------------------------- </para>
    /// <para> DEBUG: 情報を表します。動作確認のために必要な情報であり、基本的に「ユーザーが気にする必要のない情報」です。</para>
    /// <para> TRACE: 情報を表します。DEBUGと用途は同じですが、DEBUGよりも更に詳細な情報や、細かいステップ数で記録します。</para>
    /// </summary>
    public enum LogLevelEnum
    {
        FATAL, ERROR, WARNING, NOTICE, INFO, MEMO, DEBUG, TRACE
    }
}
