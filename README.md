UnityのRigidbodyでゴムボールっぽいなにかを作る実験
====

//Gistに書こうと思ったんですが、やっぱりPJごと上げてしまったのでこっちに。

## 元ネタ

Phunっていう物理演算シミュレータみたいなソフトウェアがあります。

これでわりと昔に、ロコロコというゲームの動きを再現した人がいました。

[Phun×Locoroco 作ってみた その２ - ニコニコ動画:GINZA ][1]

そこそこふわっとした謎の質感のものができていて面白いです。

今回はこのアイディアをお借りしてゴムボールっぽいなにかを作ろうとしてみました。

こんな感じのものができました。

[結果動画][2]

今回はこれがどうやって実現されているかを書きたいと思います。

といっても、わかりづらそうなので、プロジェクトごとアップロードもしました。

※もし作者の方がなんらかの形で権利を主張される場合、該当する箇所あるいは全部を修正します。ご連絡はTwitter @rootsu1024xまで。

## 構造

だいたいの物理演算は剛体を扱う前提なので、そのうえで物理演算の働くゴムボールのようなものを作るのは発想の転換が必要になります。

この構造の発想を今回先ほどの動画の方からお借りしました。

こんな感じです。

[rigidbody構造][3]

周囲にBox Collider+RigidbodyのGameObjectをぐるっと配置してHinge Jointでつなぎます。

それを中央のSphere ColliderにSpring Jointでつないであげます。

あとは(まだ実験段階なので)安定のためにPosition,RotationともにほとんどをFreezeしてあげます。

## 表示

[rigidbodyだけ][4]

Rigidbodyだけでもそこそこぷにっとした感じになるのですが、やっぱり見た目大事です。

メッシュがぷにってへこんだらうれしいですよね！

ので、今回はメッシュを直接いじることにします。

MeshBend.csがそれです。

InspectorからrubberBodiesに周囲の剛体を角度的に順番に入れてあげて、その角度ごとの移動量分、メッシュを法線方向に押し戻してあげています。


  [1]: http://www.nicovideo.jp/watch/sm8670714
  [2]: https://dl.dropboxusercontent.com/u/52614173/Gist/UnityLocoPo/rec.mp4
  [3]: https://dl.dropboxusercontent.com/u/52614173/Gist/UnityLocoPo/unitylocoppo.png
  [4]: https://dl.dropboxusercontent.com/u/52614173/Gist/UnityLocoPo/unitylocoppo2.png
