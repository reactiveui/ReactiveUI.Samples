# ⚙️ ReactiveUI Samples

<a href="https://github.com/reactiveui/reactiveui">
  <img width="90" heigth="90" src="https://raw.githubusercontent.com/reactiveui/styleguide/master/logo/main.png">
</a>

A comprehensive collection of sample projects demonstrating the power and usage of **ReactiveUI** across various UI frameworks.

---

## 📑 Table of Contents
- [Available Samples](#-available-samples)
- [Project Overview](#-project-overview)
- [Directory Structure](#-directory-structure)
- [Key ReactiveUI Concepts](#-key-reactiveui-concepts--implementations)
- [Setup & How to Run a Sample](#️-setup--how-to-run-a-sample)
- [Contributing](#-contributing)
- [License](#-license)

---

## ✨ Available Samples

This repository contains ReactiveUI samples for the following frameworks:

- ### [Avalonia](https://github.com/reactiveui/ReactiveUI.Samples/tree/main/avalonia)
- ### [Blazor](https://github.com/reactiveui/ReactiveUI.Samples/tree/main/blazor)
- ### [Testing](https://github.com/reactiveui/ReactiveUI.Samples/tree/main/testing)
- ### [Uno Platform - Android, iOS, macOS, Gtk, Tizen, Wpf, UWP, and Wasm](https://github.com/reactiveui/ReactiveUI.Samples/tree/main/Uno)
- ### [Windows Forms](https://github.com/reactiveui/ReactiveUI.Samples/tree/main/winforms)
- ### [Windows Presentation Foundation - C#, F#](https://github.com/reactiveui/ReactiveUI.Samples/tree/main/wpf)
- ### [Xamarin - Android, iOS, UWP](https://github.com/reactiveui/ReactiveUI.Samples/tree/main/Xamarin)

---

## 📌 Project Overview

This repository is designed to be a practical guide for developers looking to learn and implement **ReactiveUI**.  
Whether you're a beginner getting started with the **Model-View-ViewModel (MVVM)** pattern or an experienced developer exploring advanced reactive patterns, these samples provide clear, working examples.

### 🔹 Why This Repository?
- **Learn by Example:** See concrete implementations of ReactiveUI features in different real-world scenarios.  
- **Best Practices:** The samples demonstrate robust, maintainable, and testable application patterns.  
- **Cross-Platform:** Explore how one reactive model applies across desktop, mobile, and web frameworks.  

---

## 📂 Directory Structure
```
📦 ReactiveUI.Samples
│-- 📂 .github/          (GitHub Actions and workflow configurations)
│-- 📂 avalonia/         (Sample project for the Avalonia Framework)
│-- 📂 blazor/           (Sample project for Blazor)
│-- 📂 Uno/              (Sample projects for the Uno Platform)
│-- 📂 winforms/         (Sample project for Windows Forms)
│-- 📂 wpf/              (Sample projects for WPF in C# and F#)
│-- 📂 Xamarin/          (Sample projects for Xamarin.Forms)
│-- 📜 .gitignore        (Git ignore rules)
│-- 📜 LICENSE           (Project software license)
│-- 📜 README.md         (This file)
│-- 📜 ReactiveUI.Samples.sln (Main solution file for all samples)
│-- 📜 ReactiveUI.Samples.Android.sln
│-- 📜 ReactiveUI.Samples.iOS.sln
│-- 📜 ReactiveUI.Samples.Windows.sln
```
---

## 🚀 Key ReactiveUI Concepts & Implementations

### 1️⃣ ViewModel-First Development with `ReactiveObject`
**Concept:**  
ViewModels are the heart of a ReactiveUI app. They inherit from `ReactiveObject` to support change notifications.  
Use `WhenAnyValue` to create observable streams from property changes — enabling real-time reactions, validation, and calculations.

---

### 2️⃣ Powerful, Composable Commands with `ReactiveCommand`
**Concept:**  
`ReactiveCommand` replaces `ICommand` and allows enabling/disabling commands based on observables.  
It simplifies async execution and ensures clean handling of user actions and state.

---

### 3️⃣ Deterministic Testing with `TestScheduler`
**Concept:**  
Testing async and time-based logic is traditionally tough — ReactiveUI’s `TestScheduler` makes it easy.  
It lets you simulate time flow, resulting in fast, reliable, and deterministic unit tests.

---

## 🛠️ Setup & How to Run a Sample

### 🔹 Prerequisites
- .NET SDK (6.0 or later)
- IDE: Visual Studio 2022, JetBrains Rider, or VS Code

### 🔹 Running a Sample

Clone the repository:
```bash
git clone https://github.com/reactiveui/ReactiveUI.Samples.git
```
Navigate to a sample directory:

```
cd ReactiveUI.Samples/wpf
```

Restore dependencies:

```
dotnet restore
```


Run the project:

```
dotnet run
```


Each sample folder may contain its own README.md with additional details.

##  🤝 Contributing

Contributions are always welcome!
If you’d like to add a new sample or improve an existing one, open an issue or submit a pull request.

Please read our Contributing Guide for information about the code of conduct and submission process.

##  📜 License

This project is licensed under the MIT License.
See the LICENSE
 file for more details.