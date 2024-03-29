
************************************
デスクトップ　ラプス撮影ソフトウェア
************************************


デスクトップをタイムラプス撮影して動画にしてくれるソフトウェアです。
プログラミングとかモデリングとかお絵かきメイキングとかお絵かきメイキングとかお絵かきメイキングとか各種作業記録などに使ってください


＝＝インストール＝＝
zipを展開しておしまいです

＝＝アンインストール＝＝
フォルダごと削除で消え去ります

＝＝起動方法＝＝
processVideoMaker.exeを起動してください


＝＝使い方＝＝

-----「基本」-------
・赤丸をクリックすれば録画が始ります
・赤四角をクリックすれば録画が止まります
・縦2本の赤い線は録画時に押すと録画を一時停止します
・「オプション」＞「設定」から各種設定を行うことが出来ます



-----「表示」-----
右上グレーのボックス内
上のタイマー：録画を開始してからの実経過時間です。
下のタイマー：動画の時間です。
右下の数字：作成している動画の現在の推定サイズです。

※上のタイマーの表示が安定して表示されないことがありますが仕様です。

　下のツールバー
録画中は「Recording」の表示が出ます
一時停止中は「PAUSE」の表示が出ます



-----「設定項目」-----

-撮影間隔-
キャプチャを行う間隔をミリ秒で設定してください。（1ミリ秒　＝　１／１０００秒）
小さいほど短い間隔で撮影します。

-ファイル形式-
動画ファイルの形式を設定します。

-フレームレート-
動画にした時の1秒間に再生するフレーム数です。（デフォルトは30fps）
小さくするほどカクカクします。

-品質-
動画ビットレートを指定します。
大きいほどきれいな動画になりますが容量も大きくなります。小さいほど容量が小さくなりますが映像が荒くなります。
指定したビットレート近辺で録画を行います。録画状態に応じてできた動画の容量が低くなることがあります。

　＜tips＞
　ビットレート：動画1秒間に使用する容量です。　
　15.0Mbps＝1秒間にだいたい15メガビットくらい使います。（1バイト＝8ビット）



-ファイル名-
動画のファイル名です。
指定がない場合「noname」でファイルが作成されます。
出力される動画は「（ファイル名）_（撮影日時）.（拡張子）」となります。


-保存先フォルダ-
動画を作成する場所です。
指定がない場合、プログラムがあるフォルダの「videos」内に作成されます。

右のボタンはフォルダを指定します。

その更に右のボタンは指定したフォルダを開きます。



--「録画モード」--
・通常録画
普通の録画です

・動体検知録画（MotionDetection）
動きがあった時のみ録画を行います

　-閾値-
　記録する対象領域内の画像の差分割合です。
　小さいほどわずかな変化でも記録します。

※この録画モードではインターバルを1000ms以下には設定できません。

※動作が重い、不安定な場合。計算負荷の小さい軽量版を検討してみてください。

--「録画領域の取得」--
デスクトップ上の一部領域を録画領域として指定できます。
複数モニタ環境の場合、設定ウィンドウをモニタ上に移動させて領域設定を行うことでそのモニタ上の領域を参照することが出来ます。

※「フルスクリーン」を選択すると現在設定ウィンドウを開いているモニタ領域全体を対象とします。


--「時間の焼き込み」--
動画に現在時刻を焼き込みます。


＝＝＝＝＝＝＝＝＝

**************
*　注意事項　*
**************

キャプチャ間隔を短くしすぎた場合、正確な動作は保障できません。
100ミリ秒未満の間隔では警告が出ますが、録画は可能です。
一応、1倍速で録画もできますがPCスペックに依存します。




---免責-----------------------------------------------------

このソフトウェアを使用しての損害等については責任を負いません。
使用に当たっては自己責任でお願いします

------------------------------------------------------------



＊このアプリケーションは以下のライブラリを使用しています
AForge.Video.FFMPEG



AForge.FFMPEGのライセンスによって。このプログラムには
GNU GPLｖ３ が適用されます。
詳細はlicenceフォルダ内を確認ください。

____________________________________________________________

--------------------------------
 | AKI                        
 | aquastar.dolphin@gmail.com 
--------------------------------

=========================================
   リリースノート
=========================================
　[2016/4/25]
プログラム初版

　[2016/4/28]
・各種修正
・タイマー追加
・品質設定追加

　[2016/5/2]
・各種修正
・一時停止ボタン追加

  [2016/12/21]
・バージョン情報追加
・スリープに入るなどでうまく動作しなくなる不具合の修正を試みた
・録画中にプログラムを終了しようとすると保存して終了するか選べるようになった。

　[2016/12/29]
・画面OFFに移行しない、スリープに入らない
・万が一スリープに入った場合録画を保存して停止するようにした

　[2017/05/10]
・前回の記録の設定状態を保持するようになりました

　[2018/12/07]
・差分録画機能を追加しました
・録画プログラムを分離させました
・設定用のウィンドウを表示するようにしました

　[2018/12/07]
・時計焼き込み機能の追加

　[2018/12/07]
・範囲指定録画機能の追加

　[2018/12/08]　1.2.15
・バグ修正 安定化(1.2.15)

  [2019/01/08]　1.2.16
・以下の条件で録画強制終了の通知が出ないようにしました
　「非録画時にプログラムを起動したまま、スリープして復帰した時」

  [2019/05/29]  1.3.0
・時計焼き込み大きさを録画画像に合わせて調整するようになりました。(録画時の環境によらずに動画内で一定の大きさを維持します)
　-時計焼き込みの大きさをある程度調整できます。
・差分録画機能に軽量版を搭載しました。
　通常版では動作が重かったり不安定な場合に使用してください。
・差分録画の閾値の表現を見直しました。