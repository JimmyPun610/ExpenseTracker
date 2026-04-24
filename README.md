# 💸 Expense Tracker

A privacy-first, offline-capable personal expense tracking app built with **Blazor WebAssembly** on **.NET 10**.

> All your data stays on your device — nothing is ever sent to a server.

---

## 🤖 Built with AI

This project was **mostly built by an AI agent** (GitHub Copilot) as an experiment in AI-assisted software development. The code, architecture, and UI were largely generated and iterated through natural language prompts, with human guidance and review throughout.

---

## ✨ Features

- **Add & Edit Expenses** — Log expenses with amount, date/time, category, and an optional note.
- **Built-in Calculator** — Enter amounts using a full expression calculator (supports `+`, `-`, `*`, `/`, `%`, parentheses, and sign toggle).
- **Receipt Scanning (OCR)** — Upload a receipt image to automatically extract the amount and category.
- **Analytics Dashboard** — View spending summaries with:
  - KPI cards (total, average, top category, etc.)
  - Spend-by-category pie chart
  - Spending trend bar chart
  - Top categories ranking table
  - Presets: *This Week*, *This Month*, *This Year*, *All Time*
  - Filter by category and custom date range
- **Import / Export** — Back up and restore all records as a `.CSV` file.
- **Offline / PWA** — Works without an internet connection via a service worker.
- **Privacy** — 100% client-side. Data is stored exclusively in the browser's `localStorage`.
	- **Open Source** — Free to inspect, fork, and self-host.

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | Blazor WebAssembly (.NET 10) |
| Storage | Browser `localStorage` via JS Interop |
| PWA | Service Worker |
| Styling | Custom CSS / SCSS |
| Icons | Font Awesome |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Run locally

1. Press `F5` or run `dotnet run` in the terminal.
2. Then open your browser at `https://localhost:5001` (or the URL shown in the terminal).

### Publish

The output in `bin/Release/net10.0/publish/wwwroot` can be hosted on any static file host (GitHub Pages, Azure Static Web Apps, Netlify, etc.).


## 🔒 Data Storage & Privacy

All expense records are stored **only** in your browser's local storage. No data is transmitted, uploaded, or shared with any server or third party. You can export a `.CSV` backup at any time from the **Settings** tab.

## 📄 License

This project is open source. See the repository for details:
[github.com/JimmyPun610/ExpenseTracker](https://github.com/JimmyPun610/ExpenseTracker)
