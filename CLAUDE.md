# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Unity 6 LTS (6000.0.50f1) game project for Unity 1 Week Game Jam August 2025. The project uses Universal Render Pipeline (URP) and is configured for 2D game development with a WebGL build target.

## Commands

### Unity Compilation Check
```bash
# Unity エディタのコンパイルエラーをチェック
./unity-tools/unity-compile.sh check

# Unity エディタでコンパイルをトリガー（Unity が実行中の場合）
./unity-tools/unity-compile.sh trigger
```

### Build & Test
Unity プロジェクトのビルドとテストは Unity エディタから実行します。WebGL ビルドが主なターゲットです（960x600 デフォルト解像度）。

## Architecture

### Namespace
- **Void2610.UnityTemplate** - 別プロジェクトでも再利用可能なUtilsクラスに使用される名前空間
その他のクラスはグローバル名前空間に配置されます。

### Core Dependencies
- **LitMotion** - 高性能なトゥイーンライブラリ
- **R3** - Unity 用 Reactive Extensions
- **UniTask** - Unity での async/await サポート
- **VContainer** - 依存性注入フレームワーク
- **unityroom client** - unityroom プラットフォーム統合

### Scene Structure
- `TitleScene.unity` - タイトル画面
- `MainScene.unity` - メインゲームシーン

### コード規約
- すべてのコメントは日本語で記述
- Unity のシリアライズ可能なフィールドには `[SerializeField]` を使用