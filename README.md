# 2021_gameproduction
2年時に行ったゲーム制作のプロジェクトです。  
Unity2020.3.3f1で制作しました。  

↓担当スクリプトと簡単な説明  
allEnemyDrop:任意のラウンドですべての敵が床から落ちたか確認する。  

BossStageGimmickScript:ボスのステージで一定数の敵を落としたら壁などが動くようにする。  

CameraScript:カメラの中心がプレイヤーになるようにしている。ボタンを押すことでカメラがプレイヤーを中心に公転するようになっている。プレイヤーとの間に壁があったら見えなくするようになっている。  

DoubleButtonStage:ボタンが押されたら、壁などが動くようになる。2個同時押しも対応。  

EnemyDropInSide:任意のラウンドで内側の穴にだけ敵が落ちたか確認する。  

EnemuDropOutSide:任意のラウンドで外側にだけ敵が落ちたか確認する。  

JumpScript:プレイヤーがボタンを押した方向の床の中心に飛び移る。（未使用）  

kagoStageCameraScript:ラウンドが始まる前にカメラが籠にフォーカスを当てて、プレイヤーがどこに敵を入れればいいのかわかりやすくするようにする。  

longPushSteamBrowOffScript:ボタンを長押しすることによってプレイヤーが敵をふきとばすエリアを展開する。  

ModelPosReset:モーションによるコライダーとのずれを修正する。  

PauseScript:プレイ中に一時停止をして、メニュー画面を開いてタイトルに戻るなどの操作ができるようにする。  

PictreMove:ラウンドクリアや失敗の画像の背景を動かす。  

PlayerContoroller:プレイヤーを前後に動かしたり、スティックを回すことでプレイヤーがジャンプする力をためる。（未使用）  

PlayerContorollerFreeCameraVer:プレイヤーを動かしたり、プレイヤーに一時停止処理を入れたりする。  

PlayerJumpSimple:プレイヤーのJumpの力をためる。（未使用）  
 
PlayerMoveScript:プレイヤーの移動。（未使用）  

RoundSpawnScript:プレイヤーがラウンド変更時に特定の場所からスタートするようにする。  

SettingScript:設定画面を表示し、音量などを調整できるようにする。(予定)  

Stage8Button：特定のステージでボタンにてきが当たると床の一部が落ちる。  

Stage8Out:特定のステージで敵が落ちたらリスポーンするようにしている。  

SteamBrowOffScript:スティックを回すことで敵を吹き飛ばすエリアを展開する。（未使用）  

TitleScript:ボタンを押すことでゲームをスタートできるようする。  
