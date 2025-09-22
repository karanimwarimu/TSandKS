#TS(TEXT SUMMARIZER) & KS(KEYWORD SEARCH)
# C# File Saver + Image Uploader + FastAPI NLP Backend

This project demonstrates a SIMPLE **full-stack workflow** combining:

- **C# WinForms / WPF**: file & image upload, saving metadata to SQL Server.
- **SQL Server**: relational database for storing files, images, and metadata.
- **FastAPI (Python)**: provides a REST API for:
  - Searching by ID, Name, or metadata(KEYWORDS)
  - Text summarization of file contents (using `flan-t5-base` locally , (CAN INTEGRATE LATER USING APIS FOR MORE WORKFLOWS OR BIGGER FILES ))

---

## 🚀 Features
- Generate unique code 
- Upload text files or images from the C# frontend.
- Save metadata + binary content into SQL Server.
- display infor saved 
- Query data via FastAPI backend.
- Run **local AI model** (`flan-t5-base`) for summarization.
- Cross-platform (C# app for Windows, FastAPI for backend).

---

## 📂 Project Structure
repo-root/
│── backend/ # FastAPI app
│ ├── main.py
│ ├── requirements.txt
│ └── models/ # local models
│
│── frontend/ # C# app
│ ├── Controller.cs
│ ├── Program.cs
│ └── App.config
│
│── scripts/ # SQL setup scripts
│ └── init.sql
│
│── .gitignore
│── README.md


---

## 🛠️ Installation

### 1. SQL Server Setup
install sql server and also add sql server manager for easier db mangement 
create a database and also ensure in the c# application(gen3) there in the appliction.config there is the following :

