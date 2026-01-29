# 🚀 LogParser

Lightweight, high-performance log parsing and filtering utility.  
# 🚀 LogParser

Lightweight, high-performance log parsing and filtering utility.  
Part of the **Automation CLI Toolkit** ecosystem.

---

## 📑 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Installation](#-installation)
- [Usage](#-usage)
- [Options](#-options)
- [Examples](#-examples)
- [Output](#-output)
- [Architecture](#-architecture)
- [Version](#-version)
- [License](#-license)

---

## 🔎 Overview

`LogParser` is a self-contained Windows command-line tool for:

- Parsing large log files
- Filtering by severity level
- Matching text patterns
- Applying regex filters
- Processing multiple files via glob patterns
- Producing summary statistics

---

## ✨ Features

- ✔ Streaming file processing (memory-efficient)
- ✔ Log level filtering (`error`, `warning`, `info`, `debug`, `trace`)
- ✔ Include / exclude text filtering
- ✔ Regex support
- ✔ Multiple file support (`*.log`)
- ✔ Max lines limiter
- ✔ Summary statistics
- ✔ Self-contained single-file executable

---

## 📦 Installation

Download the release executable:

```
LogParser.exe
```

No .NET runtime required.

---

## 🖥 Usage

```bash
LogParser.exe --input <path> [options]
```

---

## ⚙ Options

| Option | Description |
|--------|-------------|
| `--out <path>` | Write filtered output to file |
| `--contains <text>` | Include lines containing text |
| `--exclude <text>` | Exclude lines containing text |
| `--regex <pattern>` | Filter by regular expression |
| `--level <levels>` | error,warning,info,debug,trace |
| `--max-lines <n>` | Limit number of output lines |

---

## 📖 Examples

### Filter errors and warnings

```bash
LogParser.exe --input app.log --level error,warning
```

---

### Filter by text

```bash
LogParser.exe --input app.log --contains timeout
```

---

### Filter multiple files

```bash
LogParser.exe --input logs\*.log --level error
```

---

### Save result to file

```bash
LogParser.exe --input app.log --level error --out errors.log
```

---

## 📊 Output

Example summary:

```
Summary:
Total lines: 1250
Matched lines: 32
Error: 20
Warning: 12
```

---

## 🧠 Architecture

Project structure:

```
LogParser.Core
 ├── Models
 ├── Parsing
 ├── Filtering
 └── Processing

LogParser.Cli
 ├── CLI argument parsing
 └── Execution entry point
```

---

## 🏷 Version

```
v0.1.0
```

Initial standalone release.

---

## 📄 License

Internal project – Automation CLI Toolkit.
