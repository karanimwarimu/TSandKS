from flask import Flask, request, jsonify
from transformers import AutoTokenizer, AutoModelForSeq2SeqLM
import fitz
import os 

app = Flask(__name__)


model_name = r"E:\BIG\MODEL\flan-t5-base"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForSeq2SeqLM.from_pretrained(model_name)

@app.route('/extract', methods=['POST'])
def extract_info():
    try:
        #data = request.get_json()
        
        #instruction = data.get("instruction", "extract information").strip()
        #text = data.get("text", "").strip()

        instruction = request.form.get('instruction', '').strip()
        file = request.files.get('file')

        if not instruction:
            return jsonify({"error": "Instruction is missing"}), 400
        if not file :
            return jsonify({"error": "File is missing"}), 400
        
        temp_path = "temp.pdf"
        file.save(temp_path)

        doc = fitz.open(temp_path)
        text = ""
        for page in doc:
            text += page.get_text()
        doc.close()

        os.remove(temp_path)

        if not text.strip():
            return jsonify({"error": "No text found in PDF"}), 400

        prompt = f"{instruction}: {text}"
        inputs = tokenizer(prompt, return_tensors="pt", max_length=512, truncation=True)
        output = model.generate(**inputs, max_new_tokens=100)
        result = tokenizer.decode(output[0], skip_special_tokens=True)

        return jsonify({"EXTRACTED RESULTS ": result})

    except Exception as e:
         print(" ERROR:", str(e))
         return jsonify({"error": str(e)}), 500
        #return jsonify({"error": str(e)}), 500

if __name__ == '__main__':
    print("Server is running...")
    app.run(host = '127.0.0.1' , port=5000, debug=True)
