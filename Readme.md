# YamlToProtobuf

# これ何？

適当なデータソースからいい感じにProtobuf ByteArrayに変換するためのフレームワークです
YamlToとか言いつつ、Yaml以外からも変換できるようになってます。
Protobufはゲームのマスターデータとして使うのを想定してます。


# 使い方

```
├── Dockerfile
├── README.md
├── YamlToProtobuf.csproj
├── generated_codes
├── out
├── protos
├── src
└── yaml
```

基本的にはルートディレクトリで`dotnet run`するか、`docker run`してください。


## 各種説明

- `generated_codes` protobufから生成されたC#コードの出力先です
- `out` protobufのbytearrayが書かれたデータファイルの出力先です
- `protos` ここにprotobufの定義を書いて入れておくといい感じになります
- `src` ジェネレータやパーサーなどのコードになります
- `yaml` データソースを入れておくディレクトリになります



# インストール

サンプルコードやデータ込みでmasterブランチが運用されているので、実際に自分のプロジェクトで利用する場合はそれを消さないといけません。

自分のprivate repoにforkしてそれをsubmoduleにしてプロジェクトにインストールするもよし
.git消してcpするもよし
適当に使ってください。

## おすすめインストール

.git消して適当なディレクトリにcpする
generated_codes ディレクトリを自分にプロジェクトの任意の場所にsymlink貼る


# 使い方

## データの種類を追加する

ゲームクライアントで利用するデータの型を登録するには、protobufを定義します。
protosディレクトリ配下のサンプルコードを見るとなんとなくわかると思います。


## データパーサーを用意する
`src/Converter/ConvertTasks`配下のコードを見ると大体の流れがわかると思います。
`IConvertTask`を実装したクラスを用意して、Convertメソッド内でデータソースのパースとprotobufのファイル生成を行ってください。
必ずファイル生成しないといけないとかではないので、データ処理に必要な処理を適宜書いていくと良いと思います。


## データパーサーの処理順を決定する
(たまに処理順が重要な場合があるので)処理順を決定できるようになってます。
ITaskDefinitionを継承したクラスを用意して、任意の順にTaskを登録してください。


## データパース時に実行時データを利用する
環境変数を利用するか、IConvertContextにIConvertMetadataを追加して、そこから取ると良いと思います。


