# 🚀 LogParser

A production-ready CLI tool for structured log filtering and analysis.

---

## 📑 Table of Contents

- [Overview](#-overview)
- [Usage](#-usage)
- [Options](#-options)
- [Examples](#-examples)
- [Exit Codes](#-exit)
- [Architecture](#-architecture)
- [Build](#-build)
- [Roadmap](#-roadmap)

---

## 🔎 Overview

LogParser is a high-performance command-line utility designed for filtering,
parsing and analyzing log files in automation environments.

It supports:

- Multi-file input
- Text include/exclude filtering
- Regex filtering
- Log level filtering
- Output redirection
- Quiet and verbose modes
- Deterministic exit codes for CI/CD

LogParser is a high-performance command-line utility designed for filtering,
parsing and analyzing log files in automation environments.

---

## ✨ Usage

```bash
LogParser --input <path> [options]
```

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
| `--input <path>` | Input file or pattern (required) |
| `--out <path>` | Write matched output to file |
| `--contains <text>` | Include lines containing text |
| `--exclude <text>` | Exclude lines containing text |
| `--regex <pattern>` | Filter by regular expression |
| `--level <levels>` | error,warning,info,debug,trace |
| `--max-lines <n>` | Limit number of matched lines |
| `--quiet` | Suppress console output |
| `--verbose` | Print summary statistics |
| `--help` | Show help |
| `--version` | Show version |

---

## 📖 Examples

### Basic filtering

```bash
LogParser.Cli.exe --input app.log
```

---

### Filter errors only

```bash
LogParser.Cli.exe --input app.log --level error
```

---

### Regex filter
```bash
LogParser.Cli.exe --input app.log --regex "timeout|failed"
```

---

### Write to file

```bash
LogParser.Cli.exe --input app.log --out filtered.log
```

---

### Quiet mode (automation use)

```
Quiet mode (automation use)
```

---

### Exit Codes

| Code | Meaning |
|--------|-------------|
| `0` | Success |
| `1` | Invalid arguments / invalid regex |
| `2` | Input file not found |
| `3` | Processing error |

---

### Architecture
```
LogParser.Core
 ├── Filtering
 ├── Parsing
 └── Processing

LogParser.Cli
 ├── CLI interface
 ├── Argument handling
 └── Exit management
```

---

### Byild

```
dotnet publish LogParser.Cli.csproj \
    -c Release \
    -r win-x64 \
    --self-contained true \
    /p:PublishSingleFile=true
```

---

 ## 🚧 Roadmap 

- Streaming optimization for very large logs
- Structured JSON log support
- Performance benchmark mode
- Linux self-contained build

---

