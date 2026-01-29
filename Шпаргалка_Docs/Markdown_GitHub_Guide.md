# 📘 Markdown & GitHub README Guide

Personal reference guide for writing clean, professional README files.

---

# 1️⃣ Markdown Basics

## Headings

```
# H1
## H2
### H3
#### H4
```

Use only ONE `# H1` per document (project title).

---

## Text Formatting

Bold:
```
**bold**
```

Italic:
```
*italic*
```

Inline code:
```
`code`
```

---

## Horizontal Line

```
---
```

Used to separate sections.

---

## Lists

Unordered list:
```
- Item
- Item
- Item
```

Ordered list:
```
1. First
2. Second
3. Third
```

Nested list:
```
- Parent
  - Child
```

---

## Code Blocks

Open with three backticks:

```
```bash
```

Close with three backticks:

```
```
```

Example:

```bash
LogParser.exe --input app.log --level error
```

Always close code blocks.

---

## Tables

```
| Column | Description |
|--------|-------------|
| A      | Text        |
```

---

## Links

```
[Google](https://google.com)
```

---

## Images

```
![Alt text](image.png)
```

---

# 2️⃣ Professional README Structure

Recommended structure for CLI tools:

```
# Project Name

Short description (1–2 sentences)

## Features
## Installation
## Usage
## Options
## Examples
## Output
## Architecture
## Roadmap (optional)
## License
```

---

# 3️⃣ CLI README Best Practices

A strong CLI README must include:

✔ Clear purpose  
✔ Installation instructions  
✔ Usage syntax  
✔ Real examples  
✔ Example output  
✔ Exit codes  
✔ Architecture overview (if engineering-focused)

---

# 4️⃣ Example CLI Structure

```
## Usage

LogParser.exe --input <path> [options]
```

```
## Example

LogParser.exe --input logs\*.log --level error
```

```
## Output

Summary:
Total lines: 1250
Matched lines: 32
```

---

# 5️⃣ GitHub Professional Tips

✔ Keep it clean  
✔ Avoid long paragraphs  
✔ Use code blocks for commands  
✔ Show real examples  
✔ Make it readable in 30 seconds  

---

# 6️⃣ Common Mistakes

❌ No examples  
❌ No usage section  
❌ Huge walls of text  
❌ Mixing dev notes with user documentation  
❌ Not closing code blocks  

---

# 7️⃣ Badges (Optional)

Example badge:

```
![Version](https://img.shields.io/badge/version-0.1.0-blue)
```

Use only for public repositories.

---

# 8️⃣ When Publishing Publicly

Add:

- Screenshots (if GUI)
- Real-world use case
- Roadmap
- License type (MIT recommended for tools)
- Installation steps
- Release link

---

# 9️⃣ Personal Rule

README must answer:

1. What is this?
2. Why does it matter?
3. How do I use it?
4. What does it produce?

If these are clear — README is strong.

---

# 🔟 Versioning Reminder

Use semantic versioning:

```
MAJOR.MINOR.PATCH
```

Example:
```
1.0.0
```

- MAJOR → breaking changes
- MINOR → new features
- PATCH → fixes

---

# 🧠 Final Principle

Clarity > Decoration  
Structure > Length  
Examples > Explanation  

A clean README builds trust.
