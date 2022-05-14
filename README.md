# 2021_gameproduction
2年時に行ったゲーム制作のプロジェクトです。  
robotを動かし360°に噴射するスチームを使って指示通りに敵キャラを吹き飛ばすゲームです。

Unity2020.3.3f1で制作しました。  
プレイにはコントローラー必須です。 


# 担当スクリプト 
- [PauseScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/PauseScript.cs): プレイ中に一時停止をして、メニュー画面を開いてタイトルに戻るなどの操作ができるようにする。  
- [PlayerContorollerFreeCameraVer](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/PlayerControllerFreeCameraVer.cs): プレイヤーを動かしたり、プレイヤーに一時停止処理を入れたりする。  


- [allEnemyDrop](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/RoundClearCondition/allEnemyDrop.cs): 任意のラウンドですべての敵が床から落ちたか確認する。  
- [BossStageGimmickScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/BossStageGimmickScript.cs): ボスのステージで一定数の敵を落としたら壁などが動くようにする。  
- [CameraScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/CameraScript.cs): カメラの中心がプレイヤーになるようにしている。ボタンを押すことでカメラがプレイヤーを中心に公転するようになっている。プレイヤーとの間に壁があったら見えなくするようになっている。  
- [DoubleButtonStage](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/DoubleButtonStage.cs): ボタンが押されたら、壁などが動くようになる。2個同時押しも対応。  
- [EnemyDropInSide](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/RoundClearCondition/EnemyDropInSide.cs): 任意のラウンドで内側の穴にだけ敵が落ちたか確認する。  
- [EnemuDropOutSide](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/RoundClearCondition/EnemyDropOutSide.cs): 任意のラウンドで外側にだけ敵が落ちたか確認する。  
- [kagoStageCameraScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/kagoStageCameraScript.cs): ラウンドが始まる前にカメラが籠にフォーカスを当てて、プレイヤーがどこに敵を入れればいいのかわかりやすくするようにする。  
- [longPushSteamBrowOffScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/longPushSteamBrowOffScript.cs): ボタンを長押しすることによってプレイヤーが敵をふきとばすエリアを展開する。 
- [TitleScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/TitleScript.cs): ボタンを押すことでゲームをスタートできるようする。  
- [Stage8Button](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/Stage8Button.cs): 特定のステージでボタンにてきが当たると床の一部が落ちる。  
- [Stage8Out](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/Stage8Out.cs): 特定のステージで敵が落ちたらリスポーンするようにしている。  
- [PictureMove](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/PictureMove.cs): ラウンドクリアや失敗の画像の背景を動かす。  
- [RoundSpawnScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/RoundSpawnScript.cs): プレイヤーがラウンド変更時に特定の場所からスタートするようにする。  
- [SettingScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/SettingScript.cs): 設定画面を表示し、音量などを調整できるようにする。(予定)  
- [ModelPosReset](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/ModelPosReset.cs): モーションによるコライダーとのずれを修正する。  


### 未使用コード
- [JumpScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/NotUse/JumpScript.cs): プレイヤーがボタンを押した方向の床の中心に飛び移る。
- [PlayerContoroller](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/NotUse/PlayerController.cs): プレイヤーを前後に動かしたり、スティックを回すことでプレイヤーがジャンプする力をためる。
- [PlayerJumpSimple](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/NotUse/PlayerJumpSimple.cs): プレイヤーのJumpの力をためる。
- [PlayerMoveScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/NotUse/PlayerMoveScript.cs): プレイヤーの移動。
- [SteamBrowOffScript](https://github.com/TairikuS/2021_gameproduction/blob/main/Assets/Script/NotUse/SteamBrowOffScript.cs): スティックを回すことで敵を吹き飛ばすエリアを展開する。
