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
Filesumm/
│── backend/                # Python API (Flask/FastAPI)
│   ├── Flask_server_plus.py              # (rename flask_server.py → app.py)
│   ├── requirements.txt    # dependencies
│   ├── models             # local HuggingFace/LLM models (gitignored) (When you download your models you can place them here)
│   
│
│── frontend/               # C# desktop app
│   ├── Program.cs
│   ├── Controller.cs
│   ├── App.config          (where your sql server connection lives )
│   └── Gen3/               # (your WinForms/WPF project folder)
│
│── scripts/                # Database setup
│   └── init.sql            # schema + seed data
│
│── examples/               # Example docs to test
│   ├── testfile.docx
│   ├── testfile.pdf
│   └── zenv.docx
│
│── .gitignore
│── README.md

---

## 🛠️ Installation

### 1. SQL Server Setup
install sql server and also add sql server manager for easier db mangement 
create a database and also ensure in the c# application(gen3) there in the appliction.config there is the following :

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
    </startup>
	<connectionStrings>
		<add name="MyDbConnection"
			 connectionString="Server=MACHINENAME\INSTANCENAME;Database=DATABASENAME;Trusted_Connection=True;TrustServerCertificate=True"
				 providerName="System.Data.SqlClient" />
	</connectionStrings>
	
</configuration>
```

### 2. FASTAPI API SERVER SETUP 
Requirements: Python 3.9+

# Create and activate virtual environment
python -m venv venv
source venv/bin/activate        # Linux/macOS
venv\Scripts\activate           # Windows PowerShell

# Install dependencies
pip install -r backend/requirements.txt


Models:

By default, HuggingFace models (e.g., flan-t5-base) will download on first use into backend/models/

You can also manually place models into this folder if needed

Run the server:

cd backend
uvicorn app:app --reload


Backend will start at: http://127.0.0.1:8000

3. Frontend (C# App)

Open the frontend/Gen3 project in Visual Studio

Ensure App.config has correct DB connection string

Build and run the project

Use the interface to upload files/images, save them, and query via FastAPI

### 📌 Usage Flow

:Start SQL Server
:start the fast api server 
   where the venv is : venv\scripts\activate
   cd cd where\you get \backend
   python  flask_server_plus.py
:Launch C# frontend app
	Upload files → stored in DB → metadata saved
	Use FastAPI endpoints or frontend UI to:
	Query by ID, Name, or keyword
	Summarize content with flan-t5-base(future addition)


 ### Development Notes

.gitignore excludes venv/, .vs/, and models/ folder (to avoid pushing large binaries).

New developers should:

Clone repo

Manually create venv

Install requirements from requirements.txt

Run SQL script

### 📖 Future Extensions
put summarization feature 
Swap summarization model with larger LLMs

Cloud DB option (Azure SQL / PostgreSQL)

JWT auth for FastAPI endpoints

Dockerize backend for easier deployment

### 🤝 Contributing

Fork the repo

Create a feature branch (git checkout -b feature-x)

Commit changes

Push branch & open a Pull Request

### 📜 License

MIT License. Free to use, modify, and distribute.
   
